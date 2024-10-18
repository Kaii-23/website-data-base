using website2.Models;
using Microsoft.EntityFrameworkCore;



namespace website2.Services
{
    public class CustomerService
    {
        private readonly TlS2301364RzaContext _context;

        public CustomerService(TlS2301364RzaContext context) 
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer) 
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

    }
}
