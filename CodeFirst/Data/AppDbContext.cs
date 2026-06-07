using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Guest> Guests { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<BookingService> BookingServices { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
