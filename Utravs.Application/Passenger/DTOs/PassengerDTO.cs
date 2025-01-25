namespace Utravs.Application.Passenger.DTOs
{
    public class PassengerDTO
    {
        public Int64 Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PassportNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
    }

}
