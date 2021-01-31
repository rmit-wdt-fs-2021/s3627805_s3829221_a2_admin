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


        [HttpPut("Block/{billPayID}")]
        public async Task Block(int billPayID)
        {
            await _repo.Block(billPayID);
        }


        [HttpPut("Unblock/{billPayID}")]
        public async Task Unblock(int billPayID)
        {
            await _repo.Unblock(billPayID);
        }
    }
}
