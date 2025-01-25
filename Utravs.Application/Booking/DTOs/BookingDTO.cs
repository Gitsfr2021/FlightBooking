namespace Utravs.Application.Booking.DTOs
{
    public class BookingDTO
    {
        public long Id { get; set; }
        public long FlightId { get; set; }
        public long PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string SeatNumber { get; set; }
    }

}
