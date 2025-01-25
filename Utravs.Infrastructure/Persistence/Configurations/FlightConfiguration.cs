using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utravs.Core.Entities.CMS;


namespace Utravs.Infrastructure.Persistence.Configurations
{
    namespace Infrastructure.Persistence
    {
        public class FlightConfiguration : IEntityTypeConfiguration<Flight>
        {
            public void Configure(EntityTypeBuilder<Flight> builder)
            {
                builder.HasKey(f => f.Id);

                builder.Property(f => f.FlightNumber)
                       .IsRequired()
                       .HasMaxLength(10);

                builder.Property(f => f.Origin)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(f => f.Destination)
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(f => f.Price)
                       .HasColumnType("decimal(18,2)");

                builder.HasMany(f => f.Bookings)
                       .WithOne(b => b.Flight)
                       .HasForeignKey(b => b.FlightId)
                       .OnDelete(DeleteBehavior.Cascade);

            }
        }
    }

}
