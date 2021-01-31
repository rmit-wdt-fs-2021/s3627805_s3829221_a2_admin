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


        [HttpGet("start={start}&&end={end}")]
        public async Task<IEnumerable<Transaction>> GetAll(DateTime start, DateTime end)
        {
            var startString = start.ToString("dd/MM/yyyy h:mm:ss tt");
            var startTime = DateTime.ParseExact(startString, "dd/MM/yyyy h:mm:ss tt", null);

            var endString = end.ToString("dd/MM/yyyy h:mm:ss tt");
            var endTime = DateTime.ParseExact(endString, "dd/MM/yyyy h:mm:ss tt", null);

            return await _repo.GetAll(startTime, endTime);
        }


        [HttpGet("{customerID}&&start={start}&&end={end}")]
        public async Task<IEnumerable<Transaction>> GetAll(int customerID, DateTime start, DateTime end)
        {
            var startString = start.ToString("dd/MM/yyyy h:mm:ss tt");
            var startTime = DateTime.ParseExact(startString, "dd/MM/yyyy h:mm:ss tt", null);

            var endString = end.ToString("dd/MM/yyyy h:mm:ss tt");
            var endTime = DateTime.ParseExact(endString, "dd/MM/yyyy h:mm:ss tt", null);

            return await _repo.GetAll(customerID, startTime, endTime);
        }
    }
}
