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
    public class UsersController : Controller
    {
        private readonly LoginManager _repo;

        public UsersController(LoginManager repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IEnumerable<Login>> GetAll()
        {
            return await _repo.GetAll();
        }


        [HttpGet("{LoginID}")]
        public async Task<Login> Get(string loginID)
        {
            return await _repo.Get(loginID);
        }


        [HttpPut]
        public async Task Block(Login login)
        {
            await _repo.Block(login);

            await Task.Delay(TimeSpan.FromMinutes(1));

            await _repo.Unblock(login);
        }
    }
}
