using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices.Factories;

public interface IUserFactory
{
    User CreateUser(CreateUserCommand command);
}

public class UserFactory : IUserFactory
{
    public User CreateUser(CreateUserCommand command)
    {
        var user = new User(
            username: command.Username,
            email: command.Email,
            password: command.Password
            );

        return user;
    }
}