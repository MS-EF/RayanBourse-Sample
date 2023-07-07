
using API.Helper;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class OwnerAccessAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var jwtService = (JwtService)context.HttpContext.RequestServices.GetService(typeof(JwtService));
            var productRepository = (IProductRepository)context.HttpContext.RequestServices.GetService(typeof(IProductRepository));

            var productId = Convert.ToInt32(context.HttpContext.Request.RouteValues.Where(q => q.Key == "id").FirstOrDefault().Value);

            var appUserId = productRepository.GetOwnerId(productId).Result;

            if (appUserId != jwtService.GetTokenClaims(context.HttpContext.Request.GetJWTTokenFromRequest())
                                                .FirstOrDefault(q => q.Key == ClaimTypes.NameIdentifier).Value)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }

        }
    }
}
