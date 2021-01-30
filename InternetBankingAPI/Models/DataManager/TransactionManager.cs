using System.Collections.Generic;
using System.Threading.Tasks;
using InternetBankingAPI.Models.Repository;
using InternetBankingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InternetBankingAPI.Models.DataManager
{
    public class TransactionManager : IDataRepository<int, Transaction>
    {
        private readonly InternetBankingContext _context;


        public TransactionManager(InternetBankingContext context)
        {
            _context = context;
        }


        public async Task<Transaction> Get(int id)
        {
            return await _context.Transactions.SingleOrDefaultAsync(x => x.TransactionID == id);
        }


        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }


        public async Task<int> Update(int id, Transaction transaction)
        {
            _context.Update(transaction);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
