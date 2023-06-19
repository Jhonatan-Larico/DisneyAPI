namespace DisneyAPI.Dtos.Authentication
{
    public class AuthenticationResponse
    {
        public string? UserName { get; set; } = string.Empty;

        public string? Name { get; set; } = string.Empty;

        public string? Token { get; set; } = string.Empty;

        public DateTime Expiration { get; set; }

        public string Role { get; set; } = string.Empty;
    }
}
