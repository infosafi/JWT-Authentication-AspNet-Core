using JWTAuth.Models;
using JWTAuth.Models.DTO;

namespace JWTAuth.Repository
{
    public interface IUsers
    {
       Task<bool> UserRegistrion(Users user);
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUSerByUserPassword(string username,string password);
    }
}
