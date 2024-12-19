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
        public async Task<Customer?> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        }
        public async Task ChangePassword(int customerId, string hashedOldPassword, string hashedNewPassword)
        {
            Customer? customer = await _context.Customers.SingleOrDefaultAsync(
                c => c.CustomerId == customerId &&
                c.Password == hashedOldPassword);
            if (customer != null)
            {
                customer.Password = hashedNewPassword;
                await _context.SaveChangesAsync();
            }
        }


        public async Task<bool> DoesUsernameExistsAsync(string username)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
            return result != null;
        }

        public async Task<Customer> GetCustomerFromId(int customerId)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == customerId);
        }
        public async Task updateCustomer(Customer customer)
        {
            Customer thisCustomer = await GetCustomerFromId((int)customer.CustomerId);
            thisCustomer.FirstName = customer.FirstName;
            thisCustomer.LastName = customer.LastName;
            thisCustomer.Username = customer.Username;
            thisCustomer.Email = customer.Email;
            thisCustomer.PhoneNumber = customer.PhoneNumber;


            await _context.SaveChangesAsync();
        }
        #region hidden
        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerFromIdAsync(int id)
        {
            return await _context.Customers.FirstAsync(c => c.CustomerId == id);
        }
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            var result = await _context.Customers.FirstOrDefaultAsync(c => c.Username == username);
            return result != null;
        }
        public async Task<string> GetCustomerNameAsync(int userid)
        {
            if (userid == 0)
            {
                return "";
            }
            else
            {
                Customer customer = _context.Customers.SingleOrDefault(c => c.CustomerId == userid);
                if (customer != null)
                {
                    return $"{customer.FirstName} {customer.LastName}";
                }
                else
                {
                    return "";
                }
            }
        }
        #endregion
    }
}