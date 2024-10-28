using Application.Purchases.Commands.CreatePurchase;
using Application.Purchases.Commands.DeletePurchase;
using Application.Purchases.Commands.UpdatePurchase;
using Application.Purchases.Queries.GetPurchaseById;
using Application.Purchases.Queries.GetPurchasesByEvent;
using Application.Purchases.Queries.GetUserPurchases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            var purchaseResponse = await Mediator.Send(new GetPurchaseByIdQuery { Id = id });
            return Ok(purchaseResponse);
        }

        [HttpGet("byUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserPurchases(int userId)
        {
            var purchaseResponses = await Mediator.Send(new GetUserPurchasesQuery { UserId = userId });
            return Ok(purchaseResponses);
        }

        [HttpGet("byEvent/{eventId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPurchasesByEvent(int eventId)
        {
            var purchaseResponses = await Mediator.Send(new GetPurchasesByEventQuery { EventId = eventId });
            return Ok(purchaseResponses);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePurchase([FromBody] UpdatePurchaseCommand request, int id)
        {
            request.Id = id;
            var purchaseResponse = await Mediator.Send(request);
            return Ok(purchaseResponse);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            await Mediator.Send(new DeletePurchaseCommand { Id = id });
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePurchase([FromBody] CreatePurchaseCommand request)
        {
            var purchaseResponse = await Mediator.Send(request);
            return CreatedAtAction(nameof(GetPurchaseById), new { id = purchaseResponse.Id }, purchaseResponse);
        }
    }
}
