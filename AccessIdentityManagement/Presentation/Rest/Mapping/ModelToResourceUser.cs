using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping.Resources;
using HashNode.API.UserManagement.Domain.Model.Entities;
using Profile = AutoMapper.Profile;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping;

public class ModelToResourceUser : Profile
{
    public  ModelToResourceUser()
    {
        CreateMap<User, UserResource>();
    }
}