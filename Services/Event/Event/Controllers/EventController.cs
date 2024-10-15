using EF_ServiceManagement.BLL.DTO.Service;
using EF_ServiceManagement.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_ServiceManagment.WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService serviceManager)
        {
            _eventService = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEvents()
        {

            var services = await _eventService.GetAsync();
            return Ok(services);

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventById(int id)
        {
            var service = await _eventService.GetByIdAsync(id);
            return Ok(service);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequest serviceRequest)
        {
            await _eventService.InsertAsync(serviceRequest);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] EventRequest serviceRequest)
        {
            var service = await _eventService.GetByIdAsync(id);
            await _eventService.UpdateAsync(serviceRequest);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var service = await _eventService.GetByIdAsync(id);
            await _eventService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("byCategory/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventsByCategory(int categoryId)
        {
            var services = await _eventService.GetEventsByCategoryAsync(categoryId);
            return Ok(services);
        }

        [HttpGet("byTags")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventsByTags([FromQuery] string[] tags)
        {
            var services = await _eventService.GetEventsByTagsAsync(tags);
            return Ok(services);
        }
    }
}
