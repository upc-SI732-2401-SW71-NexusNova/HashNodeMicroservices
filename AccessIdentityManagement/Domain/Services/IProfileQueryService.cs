using AutoMapper;
using HashNode.API.AccessIdentityManagement.Domain.Queries;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

public interface IProfileQueryService
{
    Task<Profile> handle(GetProfileByIdQuery query);
    Task<Model.Entities.Profile> handle(GetProfileByTitleQuery query);
    Task<IEnumerable<Model.Entities.Profile>> handle(GetAllProfileQuery query);
    
}