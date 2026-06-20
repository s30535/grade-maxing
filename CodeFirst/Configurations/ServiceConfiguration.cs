using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.ServiceId);
        builder.Property(s => s.ServiceId).HasColumnType("int");
        builder.Property(s => s.Name).HasMaxLength(100);
        builder.Property(s => s.Price).HasColumnType("float");
        builder.Property(s => s.Description).HasMaxLength(100);

       
        builder.ToTable("Services");

        builder.HasData(new List<Service>
        {
            new() { ServiceId = 1, Name = "idk", Price=100, Description = "nwm"},
            new() { ServiceId = 2, Name = "idk", Price=100, Description = "nwm"},
            new() { ServiceId = 3, Name = "idk", Price=100, Description = "nwm"},
        });
    }
}