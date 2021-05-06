using System;
using ERP.Domain.Core.Abstract;
using ERP.Domain.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ERP.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorization : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (Person)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new UnauthorizedResult();
                Console.ReadKey();
            }
        }
    }
}