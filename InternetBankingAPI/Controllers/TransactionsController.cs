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
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionManager _repo;

        public TransactionsController(TransactionManager repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _repo.GetAll();
        }


        [HttpGet("{customerID}")]
        public async Task<IEnumerable<Transaction>> GetAll(int customerID)
        {
            return await _repo.GetAll(customerID);
        }
    }
}
