using System.ComponentModel.DataAnnotations;

namespace CodeFirst.DTOs;

public class AddGuestDTO
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [MaxLength(9)]
    public string Phone { get; set; } = string.Empty;

    public AddBookingDTO Booking { get; set; } = null!;
}

public class AddBookingDTO
{
    public int RoomId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
}