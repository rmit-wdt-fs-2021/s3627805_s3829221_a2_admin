using System.Collections.Generic;
using System.Threading.Tasks;
using InternetBankingAPI.Models.Repository;
using InternetBankingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InternetBankingAPI.Models.DataManager
{
    public class CustomersManager : IDataRepository<int, Customer>
    {
        private readonly InternetBankingContext _context;


        public CustomersManager(InternetBankingContext context)
        {
            _context = context;
        }


        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(x => x.CustomerID == id);
        }


        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }


        public async Task<int> Update(int id, Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
