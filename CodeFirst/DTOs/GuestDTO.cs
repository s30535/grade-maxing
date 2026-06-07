namespace CodeFirst.DTOs;

public class GuestDTO
{
    public int GuestId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<BookingDTO> Bookings { get; set; } = [];
}
public class BookingDTO
{
    public int BookingId { get; set; }
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public RoomDTO Room { get; set; } = null!; 
}

public class RoomDTO
{
    public int RoomId { get; set; }
    public int RoomNumber { get; set; }
    public string Type { get; set; } = string.Empty;
    public double PricePerNight { get; set; }
    public string Status { get; set; } = string.Empty;
}