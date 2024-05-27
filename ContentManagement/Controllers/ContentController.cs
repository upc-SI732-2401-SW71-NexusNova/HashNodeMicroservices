using ContentManagement.ContentDomain.Models;
using ContentManagement.ContentDomain.Models.Dto;
using ContentManagement.ContentInfraestructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ContentManagement.Controllers
{
    [Route("api/conferences")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ILogger<ContentController> _logger;
        private readonly ConferenceDbContext _db;

        public ContentController(ILogger<ContentController> logger, ConferenceDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Retrieves a conference by ID.
        /// </summary>
        /// <param name="id">The id of the conference to retrieve.</param>
        /// <returns>The conference associated with the given id.</returns>
        /// <response code="200">Returns the conference if found.</response>
        /// <response code="400">If the request is invalid.</response>
        /// <response code="404">If the conference is not found.</response>
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ConferenceDto>> GetConferences()
        {
            _logger.LogInformation("Get conferences");

            return Ok(_db.Conferences.ToList());
        }

        
        [HttpGet("id", Name = "GetConference")]
        [SwaggerOperation(Summary = "Get conference by id", Description = "Retrieves a conference by the specified id.")]
        [SwaggerResponse(200, "Conference found", typeof(ProfileResource))]
        [SwaggerResponse(400, "Invalid request", typeof(BadRequestResult))]
        [SwaggerResponse(404, "Conference not found", typeof(NotFoundResult))]
        public ActionResult<ConferenceDto> GetConferenceById(int id)
        {
            if (id <= 0) return BadRequest();
            var conference = _db.Conferences.FirstOrDefault(c => c.Id == id);

            if (conference == null) return NotFound();
            return Ok(conference);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new conference", Description = "Creates a new conference with the provided details.")]
        [SwaggerResponse(201, "Conference created", typeof(ProfileResource))]
        [SwaggerResponse(400, "Conference creation failed", typeof(BadRequestResult))]
        public ActionResult<ConferenceDto> CreateConference([FromBody] ConferenceDto conferenceDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Conference conference = new()
            {
                userId = conferenceDto.userId,
                Title = conferenceDto.Title,
                Description = conferenceDto.Description,
                CreationDate = DateTime.Today
            };

            _db.Conferences.Add(conference);
            _db.SaveChanges();

            return CreatedAtRoute("GetConference", new { id = conference.Id }, conferenceDto);
        }

        /*[HttpPatch("id")]
        public IActionResult UpdatePartialConference(int id, JsonPatchDocument<ConferenceDto> patchDto)
        {
            if (patchDto == null || id == 0) return BadRequest();
            
            
        }*/
    }
}
