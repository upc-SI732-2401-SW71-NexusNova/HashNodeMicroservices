using AutoMapper;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices.Facades;
using HashNode.API.AccessIdentityManagement.Domain.Queries;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices;

public class ProfileQueryServiceImpl: IProfileQueryService
{
    private readonly IProfileFacade _profileFacade;
    private readonly IUserFacade _userFacade;

    public ProfileQueryServiceImpl(IProfileFacade profileFacade, IUserFacade userFacade)
    {
        _profileFacade = profileFacade;
        _userFacade = userFacade;
    }
    public async Task<Domain.Model.Entities.Profile> handle(GetProfileByIdQuery query)
    {
        return await _profileFacade.GetProfileByIdAsync(query.ProfileId);
    }

    public async Task<Domain.Model.Entities.Profile> handle(GetProfileByTitleQuery query)
    {
        var user = await _userFacade.GetUserByUsernameAsync(query.ProfileTitle);
        if (user == null) return null;
        return await _profileFacade.GetProfileByTitleAsync(user.Id);
    }

    public async Task<IEnumerable<Domain.Model.Entities.Profile>> handle(GetAllProfileQuery query)
    {
        return await _profileFacade.GetAllProfilesAsync();
    }
}