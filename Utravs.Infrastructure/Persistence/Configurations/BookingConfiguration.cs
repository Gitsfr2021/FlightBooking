using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utravs.Core.Entities.CMS;


namespace Utravs.Infrastructure.Persistence.Configurations
{
    namespace Infrastructure.Persistence
    {
        public class BookingConfiguration : IEntityTypeConfiguration<Booking>
        {
            public void Configure(EntityTypeBuilder<Booking> builder)
            {
                builder.HasKey(b => b.Id);

                builder.Property(b => b.SeatNumber)
                       .IsRequired()
                       .HasMaxLength(10);

                builder.Property(b => b.BookingDate)
                       .IsRequired();

                builder.HasOne(b => b.Flight)
                       .WithMany(f => f.Bookings)
                       .HasForeignKey(b => b.FlightId);

                builder.HasOne(b => b.Passenger)
                       .WithMany(p => p.Bookings)
                       .HasForeignKey(b => b.PassengerId);

            }
        }
    }

}
