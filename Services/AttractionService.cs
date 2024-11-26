using Microsoft.EntityFrameworkCore;
using website2.Models;

namespace website2.Services
{
    public class AttractionService
    {
        private readonly TlS2301364RzaContext _context;
        public AttractionService(TlS2301364RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
        public async Task AddTicketSync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
