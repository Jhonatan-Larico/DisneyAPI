using DisneyAPI.Dtos;
using DisneyAPI.Dtos.Authentication;
using DisneyAPI.IdentyEntities;
using DisneyAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DisneyAPI.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtService _jwtService;
        private readonly ISendEmailService _emailService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IJwtService jwtService, ISendEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
            _emailService = emailService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<AuthenticationResponse>> Register(RegisterDto registerDto)
        {
            AuthenticationResponse authenticationResponse;

            //Create user
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Name = registerDto.Name,
                Email = registerDto.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                if (registerDto.Role == RoleTypeOptions.Admin)
                {
                    //Step 1, Create the role in AspNetRoles table
                    //Create "Admin" role
                    if (await _roleManager.FindByNameAsync(RoleTypeOptions.Admin.ToString()) is null)
                    {
                        ApplicationRole adminRole = new ApplicationRole()
                        {
                            Name = RoleTypeOptions.Admin.ToString()
                        };
                        await _roleManager.CreateAsync(adminRole);
                    }

                    //Step2, Create the row into AspNetUserRoles table
                    //Add the new user into "Admin" role
                    await _userManager.AddToRoleAsync(user, RoleTypeOptions.Admin.ToString());

                    //jwt
                    authenticationResponse = _jwtService.CreateJwtToken(user, RoleTypeOptions.Admin.ToString());
                }
                else
                {
                    if (await _roleManager.FindByNameAsync(RoleTypeOptions.User.ToString()) is null)
                    {
                        ApplicationRole userRole = new ApplicationRole()
                        {
                            Name = RoleTypeOptions.User.ToString()
                        };
                        await _roleManager.CreateAsync(userRole);
                    }
                    //Add the new user into "User" role
                    await _userManager.AddToRoleAsync(user, RoleTypeOptions.User.ToString());

                    //jwt
                    authenticationResponse = _jwtService.CreateJwtToken(user, RoleTypeOptions.User.ToString());
                }

                //sign-in
                //await _signInManager.SignInAsync(user, isPersistent: false);
                EmailDto email = new EmailDto()
                {
                    To = registerDto.Email,
                    Subject = "Registration",
                    Message = "Thanks for registration"
                };

                _emailService.SendEmail(email);



                return Ok(authenticationResponse);
            }
            else
            {
                string errorMessage = string.Join(" | ", result.Errors.Select(e => e.Description)); //error1 | error2
                return Problem(errorMessage);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {  

            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(loginDto.UserName);
                var roles = await _userManager.GetRolesAsync(user);

                if (user == null)
                {
                    return NoContent();
                }
                //sign-in
                //await _signInManager.SignInAsync(user, isPersistent: false);

                //jwt
                var authenticationResponse = _jwtService.CreateJwtToken(user, roles.FirstOrDefault()!);

                return Ok(authenticationResponse);
            }

            else
            {
                return Problem("Invalid email or password");
            }
        }


        [HttpGet("logout")]
        public async Task<IActionResult> GetLogout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }
    }
}
