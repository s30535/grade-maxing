namespace CodeFirst.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<BookingService> BookingServices { get; set; } = [];
}