namespace CodeFirst.DTOs;

public class AddGuestDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone{ get; set; } = string.Empty;
    public AddBookingDTO Booking { get; set; } = null!;
}
public class AddBookingDTO
{
    public int GuestId { get; set; }
    public int RoomId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public RoomDTO Room { get; set; } = null!;
}