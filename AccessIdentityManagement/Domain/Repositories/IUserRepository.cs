using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Domain.Repositories;

public interface IUserRepository
{
    
    
    Task<IEnumerable<User>> ListAllUsersAsync();
    Task CreateUserAsync(User newUser);
    bool UserExists(string userId);
    Task<User> FindUserByIdAsync(string userId);
    Task<User> FindUserByEmailAsync(string email);
    Task UpdateAsync(User updatedUser);
    Task DeleteAsync(User deleteUser);
    
}