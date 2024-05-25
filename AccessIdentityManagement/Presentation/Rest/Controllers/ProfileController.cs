using System.Net.Mime;
using AutoMapper;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping.Resources;
using HashNode.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Access Identity Management")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly IMapper _mapper;

    public ProfileController(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }
    
    
    [HttpGet("{username}")]
    public async Task<IActionResult> GetProfileByUsernameAsync(string username)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var profile = await _profileService.GetAllProfiles();
        if (profile == null)
            return NotFound();
        return Ok(_mapper.Map<ProfileResource>(profile));
    }
    [HttpPost]
    public async Task<IActionResult> CreateNewConferenceAsync([FromBody] CreateProfileResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var command = _mapper.Map<CreateProfileResource, CreateProfileCommand>(resource);
        var response = await _profileService.CreateProfile(command);
        if (!response.Success)
            return BadRequest(response.Message);
        var conferenceResource = _mapper.Map<Profile, ProfileResource>(response.Resource);
        return Created(nameof(CreateNewConferenceAsync), conferenceResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfileByIdAsync(string id)
    {
        var command = new DeleteProfileCommand(id);
        var response = await _profileService.DeleteProfile(command);
        if (!response.Success)
            return BadRequest(response.Message);
        return NoContent();
    }
  

    
}