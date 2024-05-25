using AutoMapper;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping.Resources;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping;

public class ResourceToCommandUser : Profile
{
    public  ResourceToCommandUser()
    {
        CreateMap<CreateUserResource, CreateUserCommand>();
        CreateMap<UpdateUserResource, UpdateUserCommand>();
    }
}