using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services;

public interface IProfileService
{
    Task<ProfileResponse> CreateProfile(CreateProfileCommand command);
    Task<ProfileResponse> UpdateProfile(string id, UpdateProfileCommand command);
    Task<ProfileResponse> DeleteProfile(DeleteProfileCommand command);
    Task<AutoMapper.Profile> GetProfileById(string profileId);
    Task<Profile> GetProfileByTitle(string title);
    Task<IEnumerable<Profile>> GetAllProfiles();
}