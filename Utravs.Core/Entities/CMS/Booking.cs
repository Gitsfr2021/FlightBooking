using Utravs.Core.Entities.Base;

namespace Utravs.Core.Entities.CMS
{
    public class Booking : BaseEntity
    {
        #region Properties
        public Int64 FlightId { get; set; }
        public Int64 PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public string SeatNumber { get; set; }
        #endregion

        #region Relation
        public virtual  Flight Flight { get; set; } = null!;
        public virtual  Passenger Passenger { get; set; } = null!;
        #endregion
    }
}
