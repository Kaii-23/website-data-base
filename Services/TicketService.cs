using Microsoft.EntityFrameworkCore;
using website2.Models;
namespace website2.Services

{{
    public class TicketService
    {
        private readonly TlS2301364RzaContext _context;
        public TicketService(TlS2301364RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
    }
}