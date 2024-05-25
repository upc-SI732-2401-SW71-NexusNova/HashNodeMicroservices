using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

namespace HashNode.API.AccessIdentityManagement.Domain.Services;

public interface IUserCommandService
{
    Task<UserResponse> handle(CreateUserCommand command);
    Task<UserResponse> handle(string id, UpdateUserCommand command);
    Task<UserResponse> handle(DeleteUserCommand command);
}