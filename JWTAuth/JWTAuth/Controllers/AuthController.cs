using JWTAuth.Models;
using JWTAuth.Models.DTO;
using JWTAuth.Repository;
using JWTAuth.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IUsers _userservice;
        private readonly IToken _tokenService;

        public AuthController(IUsers userService, IToken tokenservice)
        {
            _userservice = userService;
            _tokenService = tokenservice;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> UserRegistration(Users userinfo)
        {
          bool result=  await _userservice.UserRegistrion(userinfo);
            string message = "Data Update Faild";
            if(result)
            {
                message = "Data Update Successfully";
            }
            return Ok(message);
        }

        [Authorize]
        [HttpGet("all-users")]
        public async Task<IActionResult> AllUsers()
        {
            List<Users> result = await _userservice.GetAllUsers();
          
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            UsersDto userinfo = new UsersDto();           
            userinfo.Email = email;
            Users result = await _userservice.GetUSerByUserPassword(email, password);
            if (result is not null)
            {
                var accessToken = _tokenService.CreateAccessToken(result);
                var refreshToken = _tokenService.CreateRefreshToken();
                userinfo.UserId = result.Id.ToString();
                userinfo.RefreshToken = refreshToken;
                userinfo.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                return Ok(new
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken,
                    Userinfo = userinfo
                });
                
            }

            return Ok("User Not Found");
        }
    }
}
