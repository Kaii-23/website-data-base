using Microsoft.EntityFrameworkCore;
using website2.Models;

namespace website2.Services
{
    public class RoomService
    {
        private readonly TlS2301364RzaContext _context;
        public RoomService(TlS2301364RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(int roomNumber)
        {
            return await _context.Rooms.FirstAsync(r => r.RoomNumber == roomNumber);
        }
    }
}