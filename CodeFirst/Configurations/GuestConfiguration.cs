using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.HasKey(g => g.GuestId);
        builder.Property(g => g.GuestId).HasColumnType("int");
        builder.Property(g => g.FirstName).HasMaxLength(50);
        builder.Property(g => g.LastName).HasMaxLength(100);
        builder.Property(g => g.Email).HasMaxLength(100);
        builder.Property(g => g.Phone).HasMaxLength(9);
        builder.ToTable("Guests");

        builder.HasData(new List<Guest>
        {
            new() { GuestId = 1, FirstName = "John", LastName = "Doe", Email = "example@gmail.com"},
            new() {GuestId = 2, FirstName = "Jane", LastName = "Smith", Email = "xample@gmail.com"},
            new() {GuestId = 3, FirstName = "Jane", LastName = "Doe", Email = "xample@gmail.com"},
        });
    }
}