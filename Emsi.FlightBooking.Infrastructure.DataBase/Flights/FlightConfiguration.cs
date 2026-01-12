using Emsi.FlightBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emsi.FlightBooking.Infrastructure.DataBase.Flights;

public class FlightConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.DepartureFrom).HasMaxLength(30);
        builder.Property(x => x.ArrivalTo).HasMaxLength(30);
    }
}