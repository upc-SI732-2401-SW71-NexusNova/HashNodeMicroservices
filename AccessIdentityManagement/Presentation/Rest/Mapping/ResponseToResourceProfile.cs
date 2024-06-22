using AutoMapper;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping.Resources;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping;

public class ResponseToResourceProfile: Profile
{
    public  ResponseToResourceProfile()
    {
        CreateMap<ProfileResponse, ProfileResource>();
    }
}