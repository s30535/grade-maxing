using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.BookingId);
        builder.Property(b => b.BookingId).HasColumnType("int");
        builder.Property(b => b.GuestId).HasColumnType("int");
        builder.Property(b => b.RoomId).HasColumnType("int");
        builder.Property(b => b.CheckIn).HasColumnType("datetime");
        builder.Property(b => b.CheckOut).HasColumnType("datetime");
        
        builder.HasOne(b => b.Guest)
            .WithMany(g => g.Bookings)
            .HasForeignKey(b => b.GuestId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(b => b.Room)
            .WithMany(r => r.Bookings)
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Cascade);
                 
        builder.ToTable("Bookings");

        builder.HasData(new List<Booking>
        {
            new() { BookingId = 1, GuestId = 1, RoomId = 1, CheckIn = new DateTime(2024, 1, 1), CheckOut = new DateTime(2024, 1, 2) },
            new( ) { BookingId = 2, GuestId = 1, RoomId = 1, CheckIn = new DateTime(2024, 1, 1), CheckOut = new DateTime(2024, 1, 2) },
            new() { BookingId = 3, GuestId = 1, RoomId = 1, CheckIn = new DateTime(2024, 1, 1), CheckOut = new DateTime(2024, 1, 2) },
        });
    }
}