using System.Net.Mime;
using AutoMapper;
using HashNode.API.AccessIdentityManagement.Application.Internal.Services;
using HashNode.API.AccessIdentityManagement.Domain.Commands;
using HashNode.API.AccessIdentityManagement.Presentation.Rest.Mapping.Resources;
using HashNode.API.Shared.Extensions;
using HashNode.API.UserManagement.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HashNode.API.AccessIdentityManagement.Presentation.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Access Identity Management")]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllUsersAsync()
    {
        var users = await _userService.GetAllUsers();
        return _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound();
        return Ok(_mapper.Map<UserResource>(user));
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewUserAsync([FromBody] CreateUserResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var command = _mapper.Map<CreateUserResource, CreateUserCommand>(resource);
        var response = await _userService.CreateUser(command);
        if (!response.Success)
            return BadRequest(response.Message);
        var userResource = _mapper.Map<User, UserResource>(response.Resource);
        return Created(nameof(CreateNewUserAsync), userResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(string id, [FromBody] UpdateUserResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var command = _mapper.Map<UpdateUserResource, UpdateUserCommand>(resource);
        var response = await _userService.UpdateUser(id, command);
        if (!response.Success)
            return BadRequest(response.Message);
        var userResource = _mapper.Map<User, UserResource>(response.Resource);
        return Ok(userResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync(string id)
    {
        var command = new DeleteUserCommand(id);
        var response = await _userService.DeleteUser(command);
        if (!response.Success)
            return BadRequest(response.Message);
        return NoContent();
    }
}