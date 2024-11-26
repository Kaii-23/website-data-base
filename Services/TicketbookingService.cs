using Microsoft.EntityFrameworkCore;
using website2.Models;

namespace website2.Services
{
    public class TicketbookingService
    {
        private readonly TlS2301364RzaContext _context;
        public TicketbookingService(TlS2301364RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticketbooking>> GetTicketbookingsAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketbookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }
    }
}