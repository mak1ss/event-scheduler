using ADO_Dapper_ServiceManagment.DAL.dtos.feedback;
using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADO_Dapper_ServiceManagment.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly ILogger<FeedbackController> logger;
        private readonly IFeedbackService feedbackService;
        private readonly IMapper mapper;

        public FeedbackController(ILogger<FeedbackController> logger, IFeedbackService feedbackService, IMapper mapper)
        {
            this.logger = logger;
            this.feedbackService = feedbackService;
            this.mapper = mapper;
        }

        private IActionResult HandleException(Exception ex, string action)
        {
            logger.LogError($"Error during {action}: {ex.Message}");
            return StatusCode(500, new { Message = "Internal Server Error", Details = ex.Message });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var feedbacks = feedbackService.GetAll();
                var result = mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);
                logger.LogInformation("Returned all feedbacks from the database");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "getting all feedbacks");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var feedback = feedbackService.GetById(id);
                if (feedback == null)
                {
                    logger.LogWarning($"Feedback with id {id} not found");
                    return NotFound(new { Message = $"Feedback with id {id} not found" });
                }

                var result = mapper.Map<CompleteFeedbackResponse>(feedback);
                logger.LogInformation($"Returned feedback with id {id}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"getting feedback by id {id}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] FeedbackRequest feedbackRequest)
        {
            try
            {
                var feedback = mapper.Map<Feedback>(feedbackRequest);
                var rowsAffected = feedbackService.Create(feedback);
                logger.LogInformation("Feedback created");
                return Ok(new { RowsAffected = rowsAffected });
            }
            catch (Exception ex)
            {
                return HandleException(ex, "creating feedback");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] FeedbackRequest feedbackRequest)
        {
            try
            {
                var feedback = feedbackService.GetById(id);
                if (feedback == null)
                {
                    return BadRequest(new { Message = $"Feedback with id {id} doesn't exist" });
                }

                feedback = mapper.Map<Feedback>(feedbackRequest);
                feedback.Id = id;

                feedbackService.Update(feedback);
                logger.LogInformation($"Feedback with id {id} updated");
                return Ok(feedbackService.GetById(feedback.Id));
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"updating feedback with id {id}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var feedback = feedbackService.GetById(id);

                if (feedback == null)
                {
                    return BadRequest(new { Message = $"Feedback with id {id} doesn't exist" });
                }

                feedbackService.Delete(feedback);
                logger.LogInformation($"Feedback with id {id} deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"deleting feedback with id {id}");
            }
        }

        [HttpGet("ByEvent/{eventId}")]
        public IActionResult GetByEventId(int eventId)
        {
            try
            {
                var feedbacks = feedbackService.GetFeedbacksByEvent(eventId);
                if (feedbacks == null)
                {
                    logger.LogWarning($"Feedbacks for event ID {eventId} not found");
                    return NotFound(new { Message = $"Feedbacks for event ID {eventId} not found" });
                }

                var result = mapper.Map<IEnumerable<Feedback>>(feedbacks);
                logger.LogInformation($"Returned feedbacks for event ID {eventId}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"getting feedbacks for event ID {eventId}");
            }
        }
    }
}
