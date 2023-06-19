namespace DisneyAPI.Dtos.Authentication
{
    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }   

        public string Name { get; set; }

        public string Password { get; set; }

        //Roles
        public RoleTypeOptions Role { get; set; } = RoleTypeOptions.User;
    }

    public enum RoleTypeOptions
    {
        User, Admin
    }
}
