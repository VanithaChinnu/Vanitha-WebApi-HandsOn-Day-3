using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.SecurityTokenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpWebApiWithSwagger.Filters
{
    
        public class CustomAuthFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {

                var request = filterContext.HttpContext.Request;
                if (request.Headers.ContainsKey("Authorization"))
                {
                    var authValue = request.Headers["Authorization"].ToString();
                    if (authValue != "Bearer")
                        throw new BadRequestException("Invalid request- Token present but Bearer Unavailable");
                }
                else
                {
                    throw new BadRequestException("Invalid request - No Auth token");
                }
            }

        }
}
