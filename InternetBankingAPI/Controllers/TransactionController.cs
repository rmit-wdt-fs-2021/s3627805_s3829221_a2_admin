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
    public class TransactionController : ControllerBase
    {
        private readonly TransactionManager _repo;

        public TransactionController(TransactionManager repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _repo.GetAll();
        }


        [HttpGet("{id}")]
        public async Task<Transaction> Get(int id)
        {
            return await _repo.Get(id);
        }
    }
}
