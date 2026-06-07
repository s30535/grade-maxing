using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Entities;
using CodeFirst.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _db;
    public DbService(AppDbContext db) { _db = db; }

    public async Task<IEnumerable<GuestDTO>> GetAllAsync(string? lastName = null)
    {
        return await _db.Guests
            .Where(e => lastName == null || e.LastName.ToLower().Contains(lastName.ToLower()))
            .Select(e => new GuestDTO
            {
                GuestId = e.GuestId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                Bookings = e.Bookings.Select(b => new BookingDTO()
                {
                    BookingId = b.BookingId,
                    GuestId = b.GuestId,
                    RoomId = b.RoomId,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    Room = new RoomDTO()
                    {
                        RoomId = b.Room.RoomId,
                        RoomNumber = b.Room.RoomNumber,
                        Type = b.Room.Type,
                        PricePerNight = b.Room.PricePerNight,
                        Status = b.Room.Status
                    }
                }).ToList()
            })
            .ToListAsync();
    }
  

    public async Task<GuestDTO> AddAsync(AddGuestDTO dto)
    {
        var item = new AddGuestDTO()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Booking = new AddBookingDTO()
            {
                GuestId = dto.Booking.GuestId,
                RoomId = dto.Booking.RoomId,
                CheckIn = dto.Booking.CheckIn,
                CheckOut = dto.Booking.CheckOut,
                Room = new RoomDTO()
                {
                    RoomId = dto.Booking.Room.RoomId,
                    RoomNumber = dto.Booking.Room.RoomNumber,
                    Type = dto.Booking.Room.Type,
                    PricePerNight = dto.Booking.Room.PricePerNight,
                    Status = dto.Booking.Room.Status
                }
            }
            
        };
        var room = item.Booking.Room;
        if (room == null) throw new NotFoundException(); 
        if (item.Booking.CheckIn < item.Booking.CheckOut) throw new ConflictException(); 
        await _db.AddAsync(item);
        await _db.SaveChangesAsync();
        return new GuestDTO() { FirstName = item.FirstName, LastName = item.LastName, Email = item.Email, Phone = item.Phone };
    }

}
