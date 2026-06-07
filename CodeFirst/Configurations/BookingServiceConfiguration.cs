using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class BookingServiceConfiguration : IEntityTypeConfiguration<BookingService>
{
    public void Configure(EntityTypeBuilder<BookingService> builder)
    {
        builder.HasKey(b => new { b.BookingId, b.ServiceId });
        builder.Property(b => b.ServiceDate).HasColumnType("datetime");
        
        builder.HasOne(b => b.Booking)
            .WithMany(b => b.BookingServices)
            .HasForeignKey(b => b.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(b => b.Service)
            .WithMany(s => s.BookingServices)
            .HasForeignKey(b => b.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
                 
        builder.ToTable("BookingService");

        builder.HasData(new List<BookingService>
        {
            new() { BookingId = 1, ServiceId = 1, ServiceDate = new DateTime(2024, 1, 1) },
            new() { BookingId = 2, ServiceId = 2, ServiceDate = new DateTime(2024, 1, 1) },
            new() { BookingId = 3, ServiceId = 1, ServiceDate = new DateTime(2024,1,1)}
        });
    }
}