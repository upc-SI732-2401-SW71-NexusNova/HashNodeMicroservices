using HashNode.API.AccessIdentityManagement.Domain.Queries;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Domain.Services;

public interface IUserQueryService
{
    Task<User> handle(GetUserByIdQuery query);
    Task<User> handle(GetUserByTitleQuery query);
    Task<IEnumerable<User>> handle(GetAllUserQuery query);
}