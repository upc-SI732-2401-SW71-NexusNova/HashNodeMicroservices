namespace HashNode.API.AccessIdentityManagement.Domain.Commands;

public record CreateUserCommand( string Id,string Username, string Email, string Password)
{

}