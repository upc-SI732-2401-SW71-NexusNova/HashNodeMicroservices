using HashNode.API.AccessIdentityManagement.Application.Internal.Services;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Queries;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Services;

public class UserServiceImpl : IUserService
{
    private readonly IUserCommandService _commandService;
    private readonly IUserQueryService _queryService;

    public UserServiceImpl(IUserCommandService commandService, IUserQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    public Task<UserResponse> CreateUser(CreateUserCommand command)
    {
        return _commandService.handle(command);
    }

    public Task<UserResponse> UpdateUser(string id, UpdateUserCommand command)
    {
        return _commandService.handle(id, command);
    }

    public Task<UserResponse> DeleteUser(DeleteUserCommand command)
    {
        return _commandService.handle(command);
    }

    public Task<User> GetUserById(string userId)
    {
        return _queryService.handle(new GetUserByIdQuery(userId));
    }

    public Task<User> GetUserByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }
}