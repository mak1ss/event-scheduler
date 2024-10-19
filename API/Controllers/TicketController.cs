using Application.Tickets.Commands.Delete;
using Application.Tickets.Commands.Update;
using Application.Tickets.Queries.GetTicketById;
using Application.Tickets.Queries.GetUserTickets;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticketResponse = await Mediator.Send(new GetTicketByIdQuery { Id = id});
            return Ok(ticketResponse);
        }

        [HttpGet("byUser/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTicketsByUser(int userId)
        {
            var ticketResponses = await Mediator.Send(new GetUsersTicketsQuery { UserId = userId});
            return Ok(ticketResponses);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTicket([FromBody] UpdateTicketCommand request, int id)
        {
            request.Id = id;
            var ticketResponse = await Mediator.Send(request);
            return Ok(ticketResponse);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await Mediator.Send(new DeleteTicketCommand { Id = id });
            return Ok();
        }
    }
}
