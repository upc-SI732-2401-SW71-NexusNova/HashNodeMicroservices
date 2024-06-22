using System.Net.Mime;
using AutoMapper;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Domain.Services.Communication;
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


    /// <summary>
    /// Retrieves a profile by username.
    /// </summary>
    /// <param name="username">The username of the profile to retrieve.</param>
    /// <returns>The profile associated with the given username.</returns>
    /// <response code="200">Returns the profile if found.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="404">If the profile is not found.</response>
    [HttpGet("{username}")]
    [SwaggerOperation(Summary = "Get profile by username", Description = "Retrieves a profile by the specified username.")]
    [SwaggerResponse(200, "Profile found", typeof(ProfileResource))]
    [SwaggerResponse(400, "Invalid request", typeof(BadRequestResult))]
    [SwaggerResponse(404, "Profile not found", typeof(NotFoundResult))]
    public async Task<IActionResult> GetProfileByUsernameAsync(string username)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var profile = await _profileService.GetProfileByUsername(username);
        if (profile == null)
            return NotFound();
        return Ok(profile);
    }
    [HttpPost]
    [SwaggerOperation(Summary = "Create new profile", Description = "Creates a new profile with the provided details.")]
    [SwaggerResponse(201, "Profile created", typeof(ProfileResource))]
    [SwaggerResponse(400, "Profile creation failed", typeof(BadRequestResult))]
    public async Task<IActionResult> CreateNewProfileAsync([FromBody] CreateProfileResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var command = _mapper.Map<CreateProfileResource, CreateProfileCommand>(resource);
        var response = await _profileService.CreateProfile(command);
        if (!response.Success)
            return BadRequest(response.Message);
        return Created(nameof(CreateNewProfileAsync), response.Resource);
    }
    
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete profile by ID", Description = "Deletes a profile with the specified ID.")]
    [SwaggerResponse(204, "Profile deleted", typeof(NoContentResult))]
    [SwaggerResponse(400, "Profile deletion failed", typeof(BadRequestResult))]
    public async Task<IActionResult> DeleteProfileByIdAsync(string id)
    {
        var command = new DeleteProfileCommand(id);
        var response = await _profileService.DeleteProfile(command);
        if (!response.Success)
            return BadRequest(response.Message);
        return NoContent();
    }
  

    
}