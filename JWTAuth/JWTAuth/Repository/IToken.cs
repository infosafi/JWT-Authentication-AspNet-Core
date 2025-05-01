using JWTAuth.Models;
using JWTAuth.Models.DTO;

namespace JWTAuth.Repository
{
    public interface IToken
    {
        string CreateAccessToken(Users Users);
        string CreateRefreshToken();
    }
}
