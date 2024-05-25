using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

namespace HashNode.API.AccessIdentityManagement.Domain.Services;

public interface IProfileCommandService
{
    Task<ProfileResponse> handle(CreateProfileCommand command);
    Task<ProfileResponse> handle(string id, UpdateProfileCommand command);
    Task<ProfileResponse> handle(DeleteProfileCommand command);
}