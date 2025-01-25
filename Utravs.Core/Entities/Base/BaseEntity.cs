using System.ComponentModel.DataAnnotations;

namespace Utravs.Core.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
