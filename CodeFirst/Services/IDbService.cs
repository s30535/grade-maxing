using CodeFirst.DTOs;

namespace CodeFirst.Services;

public interface IDbService
{
    Task<IEnumerable<GuestDTO>> GetAllAsync(string? LastName = null);                          // GET lista
    Task<GuestDTO> AddAsync(AddGuestDTO dto);                    // POST
}
