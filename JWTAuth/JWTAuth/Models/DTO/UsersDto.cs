namespace JWTAuth.Models.DTO
{
    public class UsersDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
