using Utravs.Core.Entities.Base;

namespace Utravs.Core.Entities.CMS
{
    public class Passenger : BaseEntity
    {
        #region Properties
        public string FullName { get; set; } 
        public string Email { get; set; } 
        public string PassportNumber { get; set; } 
        public string PhoneNumber { get; set; }
        #endregion

        #region Relation
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        #endregion
    }
}
