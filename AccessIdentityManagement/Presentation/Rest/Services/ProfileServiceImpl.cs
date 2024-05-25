using HashNode.API.AccessIdentityManagement.Application.Internal.Services;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.AccessIdentityManagement.Domain.Queries;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Services;

public class ProfileServiceImpl : IProfileService
{
    private readonly IProfileCommandService _commandService;
    private readonly IProfileQueryService _queryService;

    public ProfileServiceImpl(IProfileCommandService commandService, IProfileQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    public Task<ProfileResponse> CreateProfile(CreateProfileCommand command)
    {
        return _commandService.handle(command);
    }

    public Task<ProfileResponse> UpdateProfile(string id, UpdateProfileCommand command)
    {
        return _commandService.handle(id, command);
    }

    public Task<ProfileResponse> DeleteProfile(DeleteProfileCommand command)
    {
        return _commandService.handle(command);
    }

    public Task<AutoMapper.Profile> GetProfileById(string profileId)
    {
        return _queryService.handle(new GetProfileByIdQuery(profileId));
    }

    public Task<Profile> GetProfileByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Task<Profile> GetProfileByUsername(string username)
    {
        return _queryService.handle(new GetProfileByTitleQuery(username));
    }

    public Task<IEnumerable<Profile>> GetAllProfiles()
    {
        return _queryService.handle(new GetAllProfileQuery());
    }
}