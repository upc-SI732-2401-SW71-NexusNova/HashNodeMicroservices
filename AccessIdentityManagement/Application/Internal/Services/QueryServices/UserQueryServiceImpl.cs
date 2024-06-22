using HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices.Facades;
using HashNode.API.AccessIdentityManagement.Domain.Queries;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices;

public class UserQueryServiceImpl: IUserQueryService
{
    private readonly IUserFacade _userFacade;

    public UserQueryServiceImpl(IUserFacade userFacade)
    {
        _userFacade = userFacade;
    }
    public async Task<User> handle(GetUserByIdQuery query)
    {
        return await _userFacade.GetUserByIdAsync(query.UserId);
    }

    public async Task<User> handle(GetUserByTitleQuery query)
    {
        return await _userFacade.GetUserByEmailAsync(query.UserTitle);
    }

    public async Task<User> handle(GetUserByUsername query)
    {
        return await _userFacade.GetUserByUsernameAsync(query.username);
    }

    public async Task<IEnumerable<User>> handle(GetAllUserQuery query)
    {
        return await _userFacade.GetAllUsersAsync();
    }
}