using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.UserManagement.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HashNode.API.AccessIdentityManagement.infrastructure.Persistence.Data;

public class ProfileEntityTypeConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profiles");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Bio).IsRequired().HasMaxLength(500);
        builder.Property(p => p.ProfilePictureUrl).IsRequired().HasMaxLength(500);
        builder.Property(p => p.Location).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Website).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Github).IsRequired().HasMaxLength(100);
        
 
    }
}