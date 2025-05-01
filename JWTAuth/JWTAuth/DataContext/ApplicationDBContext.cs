
using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JWTAuth.DataContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
