using Microsoft.AspNetCore.Mvc;
using PurchaseAggregator.gRPC.DTO;
using PurchaseAggregator.gRPC.Service;

namespace PurchaseAggregator.gRPC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventPurchaseController : ControllerBase
    {
        private readonly EventPurchaseService service;

        public EventPurchaseController(EventPurchaseService service)
        {
            this.service = service;
        }

        [HttpGet("{eventId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEventPurchase(int eventId)
        {
            var res = await service.GetEventPurchase(eventId);
            return Ok(res);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseRequest request)
        {
            var purchaseResponse = await service.CreatePurchase(request);
            return CreatedAtAction(nameof(CreatePurchase), new { id = purchaseResponse.Id }, purchaseResponse);
        }
    }
}
