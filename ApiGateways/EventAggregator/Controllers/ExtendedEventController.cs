using EventAggregator.Models;
using EventAggregator.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventAggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExtendedEventController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;
        private readonly IEventService eventService;

        public ExtendedEventController(IEventService eventService, IFeedbackService feedbackService)
        {
            this.eventService = eventService;
            this.feedbackService = feedbackService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventById(int id)
        { 
            var @event = await eventService.GetEventById(id);
            var feedbacks = await feedbackService.GetFeedbacksByEventId(id);
           

            ExtendedEvent response = new ExtendedEvent
            {
                Event = @event,
                Feedbacks = feedbacks
            };
            return Ok(response);
        }
    }
}
