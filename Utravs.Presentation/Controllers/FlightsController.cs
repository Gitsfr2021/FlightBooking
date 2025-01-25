using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utravs.Application.Flights.Commands;
using Utravs.Application.Flights.DTOs;
using Utravs.Application.Flights.Queries;

namespace Utravs.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateFlight(CreateFlightDto flightDto)
        {
            var flightId = await _mediator.Send(new CreateFlightCommand { FlightDto = flightDto });
            return CreatedAtAction(nameof(GetFlights), new { id = flightId }, null);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetFlights([FromQuery] string? origin, [FromQuery] string? destination, [FromQuery] DateTime? departureDate)
        {
            var flights = await _mediator.Send(new GetFlightsQuery { Origin = origin, Destination = destination, DepartureDate = departureDate });
            return Ok(flights);
        }

        [HttpPut("{id}/seats")]
        public async Task<IActionResult> UpdateAvailableSeats(int id, [FromBody] int seatsToAdd)
        {
            var success = await _mediator.Send(new UpdateAvailableSeatsCommand { FlightId = id, SeatsToAdd = seatsToAdd });
            return success ? Ok() : NotFound();
        }
    }

}
