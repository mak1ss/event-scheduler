using ADO_Dapper_ServiceManagment.DAL.dtos.like;
using ADO_Dapper_ServiceManagment.DAL.entities;
using ADO_Dapper_ServiceManagment.DAL.interfaces.sql.services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADO_Dapper_ServiceManagment.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILogger<LikeController> logger;
        private readonly ILikeService likeService;
        private readonly IMapper mapper;

        public LikeController(ILogger<LikeController> logger, ILikeService likeService, IMapper mapper)
        {
            this.logger = logger;
            this.likeService = likeService;
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
                var likes = likeService.GetAll();
                var result = mapper.Map<IEnumerable<LikeResponse>>(likes);
                logger.LogInformation("Returned all likes from the database");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex, "getting all likes");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var like = likeService.GetById(id);
                if (like == null)
                {
                    logger.LogWarning($"Like with id {id} not found");
                    return NotFound(new { Message = $"Like with id {id} not found" });
                }

                var result = mapper.Map<LikeResponse>(like);
                logger.LogInformation($"Returned like with id {id}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"getting like by id {id}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] LikeRequest likeRequest)
        {
            try
            {
                var like = mapper.Map<Like>(likeRequest);
                var rowsAffected = likeService.Create(like);
                logger.LogInformation("Like created");
                return Ok(new { RowsAffected = rowsAffected });
            }
            catch (Exception ex)
            {
                return HandleException(ex, "creating like");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var like = likeService.GetById(id);

                if (like == null)
                {
                    return BadRequest(new { Message = $"Like with id {id} doesn't exist" });
                }

                likeService.Delete(like);
                logger.LogInformation($"Like with id {id} deleted");

                return NoContent();
            }
            catch (Exception ex)
            {
                return HandleException(ex, $"deleting like with id {id}");
            }
        }
    }
}
