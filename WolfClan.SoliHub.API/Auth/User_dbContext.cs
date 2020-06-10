using Microsoft.EntityFrameworkCore;
using RoayaApp.API.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfClan.SoliHub.API.Auth
{
    public class User_dbContext : DbContext
    {
        public User_dbContext(DbContextOptions<User_dbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
