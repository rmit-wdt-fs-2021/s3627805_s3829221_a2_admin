using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using InternetBankingAdmin.Models;

namespace InternetBankingAdmin.Filters
{
    public class AuthorizeAdminAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Get session of admin ID from login page
            var id = context.HttpContext.Session.GetInt32(nameof(Admin.ID));

            // If cannot get session from login page, redirect to login page.
            if(!id.HasValue)
                context.Result = new RedirectToActionResult("Login", "Login", null);
        }
    }
}
