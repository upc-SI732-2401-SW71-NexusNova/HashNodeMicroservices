using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Model.Entities;
using HashNode.API.UserManagement.Domain.Model.Entities;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices.Factories;

public interface IProfileFactory
{
    Profile CreateProfile(CreateProfileCommand command);
      
}

public class ProfileFactory : IProfileFactory
{
    public Profile CreateProfile(CreateProfileCommand command)
    {
        var profile = new Profile(
            id: command.Id,
            fullName: command.FullName,
            bio: command.Bio,
            profilePictureUrl: command.ProfilePictureUrl,
            location: command.Location,
            website: command.Website,
            github: command.Github
            

        );
        return profile;

    }
}
            
            