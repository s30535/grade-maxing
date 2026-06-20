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
  

    public async Task AddAsync(AddGuestDTO dto)
    {
        var room = await _db.Rooms.FindAsync(dto.Booking.RoomId);
        if (room == null) throw new NotFoundException();
        if (dto.Booking.CheckIn >= dto.Booking.CheckOut) throw new ConflictException();

        var guest = new Guest
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Phone = dto.Phone,
            Bookings =
            [
                new Booking
                {
                    RoomId = dto.Booking.RoomId,
                    CheckIn = dto.Booking.CheckIn,
                    CheckOut = dto.Booking.CheckOut
                }
            ]
        };

        await _db.Guests.AddAsync(guest);
        await _db.SaveChangesAsync();
    }

}
