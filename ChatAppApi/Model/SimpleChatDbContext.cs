using ChatAppApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatAppApi.Model
{
    public class SimpleChatDbContext : IdentityDbContext
    {
        public SimpleChatDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
