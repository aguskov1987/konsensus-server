﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Consensus.Backend.Models;

namespace Consensus.API.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeEntryAttribute : Attribute, IAuthorizationFilter
    {
        #region IAuthorizationFilter Members

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" })
                    { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        #endregion
    }
}