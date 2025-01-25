using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Utravs.Core.Entities.CMS;


namespace Utravs.Infrastructure.Persistence.Configurations
{
    namespace Infrastructure.Persistence
    {
        public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
        {
            public void Configure(EntityTypeBuilder<Passenger> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.FullName)
                       .IsRequired()
                       .HasMaxLength(150);

                builder.Property(p => p.Email)
                       .IsRequired()
                       .HasMaxLength(150);

                builder.Property(p => p.PassportNumber)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.HasMany(p => p.Bookings)
                       .WithOne(b => b.Passenger)
                       .HasForeignKey(b => b.PassengerId)
                       .OnDelete(DeleteBehavior.Cascade);

            }
        }
    }

}
