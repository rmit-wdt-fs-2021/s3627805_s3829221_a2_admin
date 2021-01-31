using System;
using System.Collections.Generic;
using System.Net.Http;
using X.PagedList;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternetBankingAdmin.Models;
using Newtonsoft.Json;
using InternetBankingAdmin.Filters;

namespace InternetBankingAdmin.Controllers
{
    [AuthorizeAdmin, Route("Mcba/Admin/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _client => _clientFactory.CreateClient("api");

        public TransactionsController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;


        public async Task<IActionResult> Index(int? page = 1)
        {
            var response = await _client.GetAsync("api/Transactions");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result = await response.Content.ReadAsStringAsync();

            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);
            transactions.Sort();

            IPagedList<Transaction> PagedTransactions = await transactions.ToPagedListAsync((int)page, 4);

            var response2 = await _client.GetAsync("api/Customers");

            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result2 = await response2.Content.ReadAsStringAsync();

            var customers = JsonConvert.DeserializeObject<List<Customer>>(result2);
            ViewData["CustomerList"] = customers;

            return View(PagedTransactions);
        }


        [HttpPost]
        public async Task<IActionResult> Index(int? customerID, DateTime? start, DateTime? end, int? page = 1)
        {
            HttpResponseMessage response = null;

            if (customerID != null && start == null && end == null)
                response = await _client.GetAsync($"api/Transactions/{customerID}");
            else if (customerID == null && start != null && end != null)
                response = await _client.GetAsync($"api/Transactions/start={start}&&end={end}");
            else if (customerID != null && start != null && end != null)
                response = await _client.GetAsync($"api/Transactions/{customerID}&&start={start}&&end={end}");
            else
                response = await _client.GetAsync("api/Transactions");
            
            if (!response.IsSuccessStatusCode)
                throw new Exception();

            var result = await response.Content.ReadAsStringAsync();

            var transactions = JsonConvert.DeserializeObject<List<Transaction>>(result);
            transactions.Sort();

            IPagedList<Transaction> PagedTransactions = await transactions.ToPagedListAsync((int)page, 4);

            return View(PagedTransactions);
        }
    }
}
