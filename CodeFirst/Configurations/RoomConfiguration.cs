using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.RoomId);
        builder.Property(r => r.RoomId).HasColumnType("int");
        builder.Property(r => r.RoomNumber).HasColumnType("int");
        builder.Property(r => r.Type).HasMaxLength(100);
        builder.Property(r => r.PricePerNight).HasColumnType("float");
        builder.Property(r => r.Status).HasMaxLength(100);
       
        builder.ToTable("Rooms");

        builder.HasData(new List<Room>
        {
            new() { RoomId = 1, RoomNumber = 101, Type = "Single", PricePerNight = 100.0f, Status = "Available" },
            new() { RoomId = 2, RoomNumber = 102, Type = "Double", PricePerNight = 150.0f, Status = "Occupied" },
            new() { RoomId = 3, RoomNumber = 103, Type = "Suite", PricePerNight = 300.0f, Status = "Available" },
        });
    }
}