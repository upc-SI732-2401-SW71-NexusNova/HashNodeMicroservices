using AutoMapper;
using HashNode.API.Shared.Domain.Services.Communication;
namespace HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

public class ProfileResponse : BaseResponse<Model.Entities.Profile>
{
    public ProfileResponse(Model.Entities.Profile resource) : base(resource)
    {
    }

    public ProfileResponse(string message) : base(message)
    {
    }
}
