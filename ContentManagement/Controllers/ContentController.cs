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
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ConferenceDto>> GetConferences()
        {
            _logger.LogInformation("Get conferences");

            return Ok(_db.Conferences.ToList());
        }

        
        [HttpGet("id", Name = "GetConference")]
        public ActionResult<ConferenceDto> GetConferenceById(int id)
        {
            if (id <= 0) return BadRequest();
            var conference = _db.Conferences.FirstOrDefault(c => c.Id == id);

            if (conference == null) return NotFound();
            return Ok(conference);
        }

        [HttpPost]
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
