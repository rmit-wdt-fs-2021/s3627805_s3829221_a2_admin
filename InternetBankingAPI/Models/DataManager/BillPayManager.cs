using System.Collections.Generic;
using System.Threading.Tasks;
using InternetBankingAPI.Models.Repository;
using InternetBankingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InternetBankingAPI.Models.DataManager
{
    public class BillPayManager : IDataRepository<int, BillPay>
    {
        private readonly InternetBankingContext _context;


        public BillPayManager(InternetBankingContext context)
        {
            _context = context;
        }


        public async Task<BillPay> Get(int id)
        {
            return await _context.BillPays.SingleOrDefaultAsync(x => x.BillPayID == id);
        }


        public async Task<IEnumerable<BillPay>> GetAll()
        {
            return await _context.BillPays.ToListAsync();
        }


        public async Task<int> Update(int id, BillPay billPay)
        {
            _context.Update(billPay);
            await _context.SaveChangesAsync();

            return id;
        }

        public async Task Block(BillPay billPay)
        {
            billPay.IsBlocked = true;
            _context.Update(billPay);
            await _context.SaveChangesAsync();
        }
    }
}
