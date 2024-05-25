using AutoMapper;
using HashNode.API.Shared.Domain.Services.Communication;
namespace HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

public class ProfileResponse : BaseResponse<Profile>
{
    public ProfileResponse(Profile resource) : base(resource)
    {
    }

    public ProfileResponse(string message) : base(message)
    {
    }
}
