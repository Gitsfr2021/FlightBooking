using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utravs.Application.Passenger.Commands;
using Utravs.Application.Passenger.DTOs;
using Utravs.Application.Passenger.Queries;


namespace Utravs.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PassengerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePassenger(CreatePassengerDto passengerDto)
        {
            try
            {
                var result = await _mediator.Send(new CreatePassengerCommand(passengerDto));

                if (!result.IsSuccess)
                {
                    return Conflict(new { Message = "Duplicate data found", DuplicateField = result.DuplicateField });
                }

                return CreatedAtAction(nameof(GetPassenger), new { id = result.PassengerId }, null);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new
                {
                    message = "Validation error",
                    errors = ex.Errors.Select(f => new
                    {
                        Field = f.PropertyName,
                        Error = f.ErrorMessage
                    })
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = "An unexpected error occurred.",
                    details = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPassenger([FromQuery] string FullName, [FromQuery] string Email, [FromQuery] string PassportNumber)
        {
            var Passenger = await _mediator.Send(new GetPassengerQuery { FullName = FullName, Email = Email, PassportNumber = PassportNumber });
            return Ok(Passenger);
        }
    }

}
