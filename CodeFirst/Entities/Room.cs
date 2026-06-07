namespace CodeFirst.Entities;

public class Room
{
    public int RoomId { get; set; }
    public int RoomNumber { get; set; }
    public string Type { get; set; } = string.Empty;
    public double PricePerNight { get; set; }
    public string Status { get; set; } = string.Empty;
    public ICollection<Booking> Bookings { get; set; } = [];
}