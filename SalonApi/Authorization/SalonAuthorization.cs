using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SalonApi.Authorization
{
    public class SalonAuthorization : AuthorizeAttribute, IAuthorizationFilter
    {
        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            var filters = context.ActionDescriptor.FilterDescriptors.ToList();
            foreach (var filter in filters)
            {
                if (filter.Filter.GetType() == typeof(Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter))
                    return;
            }
            var authHeader = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                context.Result = new ObjectResult(response);
                return;
            }
            var jwtToken = authHeader.ToString().Split(' ')[1];

            if (jwtToken == null)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                context.Result = new ObjectResult(response);
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken;
            var claims = jsonToken.Claims;
           
        }
    }
}

