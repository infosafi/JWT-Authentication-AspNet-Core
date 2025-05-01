using System.ComponentModel.DataAnnotations.Schema;

namespace JWTAuth.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? Active { get; set; } = false;
        public int Role { get; set; } = 0;


    }
}
