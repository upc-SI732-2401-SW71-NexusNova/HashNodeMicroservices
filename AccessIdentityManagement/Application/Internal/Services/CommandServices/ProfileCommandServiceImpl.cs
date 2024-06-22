using AutoMapper;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices.Factories;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Repositories;
using HashNode.API.AccessIdentityManagement.Domain.Services;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;

namespace HashNode.API.AccessIdentityManagement.Application.Internal.Services.CommandServices;

public class ProfileCommandServiceImpl : IProfileCommandService
{ 
    private readonly IProfileRepository _profileRepository;
    private readonly IMapper _mapper;
    private readonly IProfileFactory _profileFactory;
    private readonly IUserRepository _userRepository;
    
    public ProfileCommandServiceImpl(IProfileRepository profileRepository, IMapper mapper, IProfileFactory profileFactory,
        IUserRepository userRepository)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
        _profileFactory = profileFactory;
        _userRepository = userRepository;
    }
    
    
    public async Task<ProfileResponse> handle(CreateProfileCommand command)
    {
        var newProfile = _profileFactory.CreateProfile(command);
        var userExists = await _userRepository.FindUserByIdAsync(command.Id);
        if (userExists == null)
        {
            return new ProfileResponse($"An user with {command.Id} id does not exist");
        }
        try
        {
            await _profileRepository.CreateProfileAsync(newProfile);
            return new ProfileResponse(newProfile);
        }
        catch (Exception ex)
        {
            return new ProfileResponse($"An error occurred while creating the user: {ex.Message}");
        }
    }

    public async Task<ProfileResponse> handle(string id, UpdateProfileCommand command)
    {
        var existingProfile = await _profileRepository.FindProfileByIdAsync(id);
        if (existingProfile == null)
        {
            return new ProfileResponse("User not found");
        }

        existingProfile.SaveProfile(
            command.FirstName + command.LastName,
            command.Bio,
            command.ProfilePicture,
            command.Location,
            command.Website,
            command.Github
            );

        try
        {
            await _profileRepository.UpdateAsync(existingProfile);
            return new ProfileResponse(existingProfile);
        }
        catch (Exception ex)
        {
            return new ProfileResponse($"An error occurred while updating the user: {ex.Message}");
        }
    }

    public async Task<ProfileResponse> handle(DeleteProfileCommand command)
    {
        if (!_profileRepository.ProfileExists(command.profileId))
        {
            return new ProfileResponse("User not found");
        }
        try
        {
            var existingProfile = await _profileRepository.FindProfileByIdAsync(command.profileId);
            await _profileRepository.DeleteAsync(existingProfile);
            return new ProfileResponse(existingProfile);
        }
        catch (Exception ex)
        {
            return new ProfileResponse($"An error occurred while deleting the user: {ex.Message}");
        }
    }
}