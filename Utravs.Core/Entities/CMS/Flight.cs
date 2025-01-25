using Utravs.Core.Entities.Base;

namespace Utravs.Core.Entities.CMS
{
    public class Flight : BaseEntity
    {
        #region Properties
        public string FlightNumber { get; set; } 
        public string Origin { get; set; } 
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AvailableSeats { get; set; }
        public decimal Price { get; set; }
        #endregion

        #region Relation
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        #endregion
    }
}
