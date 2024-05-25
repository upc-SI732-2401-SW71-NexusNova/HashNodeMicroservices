using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices.Facades;

public interface IProfileFacade
{
    Task<Profile> GetProfileByIdAsync(string profileId);
    Task<Profile> GetProfileByTitleAsync(string title);
    Task<IEnumerable<Profile>> GetAllProfilesAsync();
}

public class ProfileFacade : IProfileFacade
{
    private readonly IProfileRepository _profileRepository;

    public ProfileFacade(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Profile> GetProfileByIdAsync(string profileId)
    {
        return await _profileRepository.FindProfileByIdAsync(profileId);
    }

    public async Task<Profile> GetProfileByTitleAsync(string title)
    {
        return await _profileRepository.FindProfileByUserIdAsync(title);
    }

    public async Task<IEnumerable<Profile>> GetAllProfilesAsync()
    {
        return await _profileRepository.ListAllProfilesAsync();
    }
}