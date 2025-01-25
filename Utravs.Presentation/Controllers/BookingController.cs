namespace Utravs.Presentation.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Utravs.Application.Booking.Commands;
    using Utravs.Application.Booking.DTOs;
    using Utravs.Application.Booking.Queries;

    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDTO bookingDto)
        {
            if (bookingDto == null)
            {
                return BadRequest("Booking details are required.");
            }

            var result = await _mediator.Send(new CreateBookingCommand { BookingDto = bookingDto });

            if (result)
            {
                return Ok("Booking created successfully.");
            }
            else
            {
                return Conflict("Could not create booking. Seats might be unavailable.");
            }
        }


        [HttpGet]
        [Route("flight/{flightId}/bookings")]
        public async Task<IActionResult> GetBookingsByFlight(long flightId)
        {
            if (flightId <= 0)
            {
                return BadRequest("Invalid flight ID.");
            }

            var bookings = await _mediator.Send(new GetBookingsByFlightQuery { FlightId = flightId });

            if (bookings == null || bookings.Count == 0)
            {
                return NotFound("No bookings found for this flight.");
            }

            return Ok(bookings);
        }
    }

}
