using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services;

public interface IUserService
{
    Task<UserResponse> CreateUser(CreateUserCommand command);
    Task<UserResponse> UpdateUser(string id, UpdateUserCommand command);
    Task<UserResponse> DeleteUser(DeleteUserCommand command);
    Task<User> GetUserById(string userId);
    Task<User> GetUserByTitle(string title);
    Task<IEnumerable<User>> GetAllUsers(); 
    
}