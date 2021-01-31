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
    public class CustomersController : Controller
    {
        private readonly CustomersManager _repo;

        public CustomersController(CustomersManager repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _repo.GetAll();
        }
    }
}
