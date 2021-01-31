﻿using System;
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
        public async Task<IActionResult> Index(int? customerID, string? start, string? end, int? page = 1)
        {
            HttpResponseMessage response = null;

            var hasStartTime = DateTime.TryParseExact(start, "MM/dd/yyyy h:mm tt", null, System.Globalization.DateTimeStyles.None, out DateTime startTime);
            DateTime parseStart = DateTime.UtcNow;
            if (hasStartTime)
            {
                var startString = startTime.ToString("yyyy-MM-dd'T'hh:mm:ss");
                parseStart = DateTime.ParseExact(startString, "yyyy-MM-dd'T'hh:mm:ss", null);
            }

            var hasEndTime = DateTime.TryParseExact(end, "MM/dd/yyyy h:mm tt", null, System.Globalization.DateTimeStyles.None, out DateTime endTime);
            DateTime parseEnd = DateTime.UtcNow;
            if (hasEndTime)
            {
                var endString = endTime.ToString("yyyy-MM-dd'T'hh:mm:ss");
                parseEnd = DateTime.ParseExact(endString, "yyyy-MM-dd'T'hh:mm:ss", null);
            }

            if (customerID != null && !hasStartTime && !hasEndTime)
                response = await _client.GetAsync($"api/Transactions/{customerID}");
            else if (customerID == null && hasStartTime && hasEndTime)
            {
                response = await _client.GetAsync($"api/Transactions/start={parseStart}&&end={parseEnd}");
            }
            else if (customerID != null && hasStartTime && hasEndTime)
            {
                response = await _client.GetAsync($"api/Transactions/{customerID}&&start={parseStart}&&end={parseEnd}");
            }
            else
                response = await _client.GetAsync("api/Transactions");
            
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
    }
}
