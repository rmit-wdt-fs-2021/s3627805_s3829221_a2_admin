using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetBankingAdmin.Models;
using Newtonsoft.Json;
using InternetBankingAdmin.Filters;

namespace InternetBankingAdmin.Controllers
{
    [AuthorizeAdmin, Route("Mcba/Admin/BillPay")]
    public class BillPayController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _client => _clientFactory.CreateClient("api");

        public BillPayController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;


        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("api/BillPay");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result = await response.Content.ReadAsStringAsync();

            var billPays = JsonConvert.DeserializeObject<List<BillPay>>(result);

            return View(billPays);
        }


        [HttpPost, Route("[Action]")]
        public async Task<IActionResult> Block(int billPayID)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(billPay), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"api/BillPay/Block/{billPayID}", null);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost, Route("[Action]")]
        public async Task<IActionResult> Unblock(int billPayID)
        {
            //var content = new StringContent(JsonConvert.SerializeObject(billPay), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"api/BillPay/Unblock/{billPayID}", null);

            return RedirectToAction(nameof(Index));
        }
    }
}
