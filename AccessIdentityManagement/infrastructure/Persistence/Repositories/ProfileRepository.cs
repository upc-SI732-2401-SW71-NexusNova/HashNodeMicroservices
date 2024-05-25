

using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.Shared.Infrastructure.Persistence.Data;
using HashNode.API.Shared.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HashNode.API.AccessIdentityManagement.infrastructure.Persistence.Repositories;

public class ProfileRepository : BaseRepository, IProfileRepository
{
 
    public ProfileRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Profile> FindProfileByIdAsync(string id)
    {
        return await _context.Profiles.FindAsync(id);
    }
    
    public async Task<Profile> FindProfileByUserIdAsync(string userId)
    {
        return await _context.Profiles.SingleOrDefaultAsync(e => e.Id == userId);
    }

    public Task UpdateAsync(AutoMapper.Profile updatedProfile)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(AutoMapper.Profile deleteProfile)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Profile>> ListAllProfilesAsync()
    {
        return await _context.Profiles.ToListAsync();
    }

    public Task CreateProfileAsync(AutoMapper.Profile newProfile)
    {
        throw new NotImplementedException();
    }

    public async Task CreateProfileAsync(Profile newProfile)
    {
        await _context.Profiles.AddAsync(newProfile);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Profile updateProfile)
    {
        _context.Profiles.Update(updateProfile);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Profile deleteProfile)
    {
        _context.Profiles.Remove(deleteProfile);
        await _context.SaveChangesAsync();
    }

    public bool ProfileExists(string profileId)
    {
        return _context.Profiles.Any(e => e.Id == profileId);
    }   
}