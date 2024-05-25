using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Infrastructure.Persistence.Data;
using HashNode.API.FeedManagement.Domain.Models.Entities;
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

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Conference entity
            builder.ApplyConfiguration(new ConferenceEntityTypeConfiguration());

            // Configure Comment entity
            builder.Entity<Comment>().ToTable("Comments");
            builder.Entity<Comment>().HasKey(c => c.Id);
            builder.Entity<Comment>().Property(c => c.Content).IsRequired().HasMaxLength(100);
            builder.Entity<Comment>().Property(c => c.CreatedAt).IsRequired();

            // Configure Post entity
            builder.Entity<Post>().ToTable("Posts");
            builder.Entity<Post>().HasKey(p => p.Id);
            builder.Entity<Post>().Property(p => p.Title).IsRequired().HasMaxLength(30);
            builder.Entity<Post>().Property(p => p.Content).IsRequired().HasMaxLength(100);
            builder.Entity<Post>().Property(p => p.PublishDate).IsRequired();


            // Relationship
            builder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .IsRequired();

            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .IsRequired();



            // Convention Naming
            builder.UseSnakeCaseNamingConvention();
        }
    }
}
