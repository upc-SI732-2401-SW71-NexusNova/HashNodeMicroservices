using AutoMapper;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Domain.Repositories;

public interface IProfileRepository
{
    Task<IEnumerable<Model.Entities.Profile>> ListAllProfilesAsync();
    Task CreateProfileAsync(Profile newProfile);
    bool ProfileExists(string profileId);
    Task<Model.Entities.Profile> FindProfileByIdAsync(string profileId);
    Task<Model.Entities.Profile> FindProfileByUserIdAsync(string userId);
    Task UpdateAsync(Profile updatedProfile);
    Task DeleteAsync(Profile deleteProfile);
}