using ContentManagement.ContentDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContentManagement.ContentInfraestructure.Persistence;

public class ConferenceDbContext: DbContext
{
    public ConferenceDbContext(DbContextOptions<ConferenceDbContext> options) :base(options)
    {
        
    }
    
    public DbSet<Conference> Conferences { get; set; }
}