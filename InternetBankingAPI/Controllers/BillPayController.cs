using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBankingAPI.Models.DataManager;
using InternetBankingAPI.Models;

namespace InternetBankingAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BillPayController : Controller
    {
        private readonly BillPayManager _repo;

        public BillPayController(BillPayManager repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<BillPay>> GetAll()
        {
            return await _repo.GetAll();
        }


        [HttpPut("Block")]
        public async Task Block(BillPay billpay)
        {
            await _repo.Block(billpay);
        }


        [HttpPut("Unblock")]
        public async Task Unblock(BillPay billpay)
        {
            await _repo.Block(billpay);
        }
    }
}
