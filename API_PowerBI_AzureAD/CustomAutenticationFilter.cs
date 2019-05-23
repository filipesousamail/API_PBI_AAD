using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API_PowerBI_AzureAD
{
    public class CustomAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Challenge(actionContext);
                return;
            }

            base.OnAuthorization(actionContext);
        }

        private void Challenge(HttpActionContext actionContext)
        {
            var authUri = "https://login.microsoftonline.com/09e251dc-5e87-48bf-b4d2-71b01adb984a/oauth2/authorize";
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", $"Bearer authorization_uri=\"{authUri}\"");


        }
    }
}