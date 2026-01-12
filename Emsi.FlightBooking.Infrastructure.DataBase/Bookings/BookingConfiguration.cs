using Emsi.FlightBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Emsi.FlightBooking.Infrastructure.DataBase.Bookings;

public class BookingConfiguration: IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.HasOne(x => x.Flight).WithMany().HasForeignKey(x => x.FlightId);
        builder.HasOne(x => x.Passenger).WithMany().HasForeignKey(x => x.PassengerId);
    }
}