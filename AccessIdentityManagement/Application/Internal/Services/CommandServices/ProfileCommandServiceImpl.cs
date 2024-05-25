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
    
    public ProfileCommandServiceImpl(IProfileRepository profileRepository, IMapper mapper, IProfileFactory profileFactory)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
        _profileFactory = profileFactory;
    }
    
    
    public Task<ProfileResponse> handle(CreateProfileCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ProfileResponse> handle(string id, UpdateProfileCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ProfileResponse> handle(DeleteProfileCommand command)
    {
        throw new NotImplementedException();
    }
}