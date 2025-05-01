using JWTAuth.DataContext;
using JWTAuth.Models;
using JWTAuth.Models.DTO;
using JWTAuth.Repository;
using Microsoft.EntityFrameworkCore;
using System;

namespace JWTAuth.Service
{
    public class UsersService(ApplicationDBContext dbContext) : IUsers
    {
        public async Task<List<Users>> GetAllUsers()
        {
           return await dbContext.Users.ToListAsync();
        }

        public async Task<Users> GetUSerByUserPassword(string username, string password)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x=>x.Email== username && x.Password== password);
        }

        public async Task<bool> UserRegistrion(Users user)
        {
            bool result = false;            
             
                await dbContext.Users.AddAsync(user);
                

                await dbContext.SaveChangesAsync();

                result = true;

         


            return result;
        }
    }
}
