using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetBankingAdmin.Filters;

namespace InternetBankingAdmin.Controllers
{

    [AuthorizeAdmin, Route("Mcba/Admin")]
    public class AdminController : Controller
    {

        [Route("Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
