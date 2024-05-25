using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.Shared.Extensions;
using HashNode.API.UserManagement.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace HashNode.API.Shared.Infrastructure.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            



            // Convention Naming
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
