using Emsi.FlightBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emsi.FlightBooking.Infrastructure.DataBase.Passengers;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Email).HasMaxLength(50);
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.FullName).HasMaxLength(50);
        builder.Property(x => x.Civility).HasMaxLength(10);
        builder.Property(x => x.Passport).HasMaxLength(30);
    }
}