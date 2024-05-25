using HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices.Factories;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices;

public class UserCommandServiceImpl : IUserCommandService
{
    private readonly IUserRepository userRepository;
    private readonly IUserFactory userFactory;

    public UserCommandServiceImpl(IUserRepository userRepository, IUserFactory userFactory)
    {
        this.userRepository = userRepository;
        this.userFactory = userFactory;
    }

    public async Task<UserResponse> handle(CreateUserCommand command)
    {
        var newUser = userFactory.CreateUser(command);
        try
        {
            await userRepository.CreateUserAsync(newUser);
            return new UserResponse(newUser);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred while creating the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> handle(string id, UpdateUserCommand command)
    {
        var existingUser = await userRepository.FindUserByIdAsync(id);
        if (existingUser == null)
        {
            return new UserResponse("User not found");
        }

        existingUser.SaveUser(command.UserName, command.Email, command.Password);

        try
        {
            await userRepository.UpdateAsync(existingUser);
            return new UserResponse(existingUser);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred while updating the user: {ex.Message}");
        }
    }

    public async Task<UserResponse> handle(DeleteUserCommand command)
    {
        if (!userRepository.UserExists(command.userId))
        {
            return new UserResponse("User not found");
        }
        try
        {
            var existingUser = await userRepository.FindUserByIdAsync(command.userId);
            await userRepository.DeleteAsync(existingUser);
            return new UserResponse(existingUser);
        }
        catch (Exception ex)
        {
            return new UserResponse($"An error occurred while deleting the user: {ex.Message}");
        }
    }
}
