namespace HashNode.API.AccessIdentityManagement.Domain.Commands;

public record CreateUserCommand( string Username, string Email, string Password)
{

}