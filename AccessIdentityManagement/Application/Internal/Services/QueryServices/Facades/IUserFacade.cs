using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.QueryServices.Facades;

public interface IUserFacade
{
    Task<User> GetUserByIdAsync(string userId);
    Task<User> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsersAsync();
    
}

public class UserFacade : IUserFacade
{
    private readonly IUserRepository _userRepository;

    public UserFacade(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserByIdAsync(string userId)
    {
        return await _userRepository.FindUserByIdAsync(userId);
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _userRepository.FindUserByEmailAsync(email);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _userRepository.ListAllUsersAsync();
    }
}