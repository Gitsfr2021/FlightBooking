using MediatR;
using Utravs.Application.Booking.Commands;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Handlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, bool>
    {
        private readonly IBookingService _bookingService;

        public CreateBookingCommandHandler(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<bool> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            return await _bookingService.CreateBookingAsync(request.BookingDto);
        }
    }

}
