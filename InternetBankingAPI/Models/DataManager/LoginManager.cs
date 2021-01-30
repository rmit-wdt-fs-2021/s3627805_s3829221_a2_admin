using System.Collections.Generic;
using System.Threading.Tasks;
using InternetBankingAPI.Models.Repository;
using InternetBankingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InternetBankingAPI.Models.DataManager
{
    public class LoginManager : IDataRepository<string, Login>
    {
        private readonly InternetBankingContext _context;


        public LoginManager(InternetBankingContext context)
        {
            _context = context;
        }


        public async Task<Login> Get(string id)
        {
            return await _context.Logins.SingleOrDefaultAsync(x => x.LoginID == id);
        }


        public async Task<IEnumerable<Login>> GetAll()
        {
            return await _context.Logins.ToListAsync();
        }


        public async Task<string> Update(string id, Login login)
        {
            _context.Update(login);
            await _context.SaveChangesAsync();

            return id;
        }


        public async Task Block(Login login)
        {
            login.IsBlocked = true;
            _context.Update(login);
            await _context.SaveChangesAsync();
        }


        public async Task Unblock(Login login)
        {
            login.IsBlocked = false;
            _context.Update(login);
            await _context.SaveChangesAsync();
        }
    }
}
