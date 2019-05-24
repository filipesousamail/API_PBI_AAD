using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens; 
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.ActiveDirectory;
using Microsoft.Owin.Security.OAuth;
using Owin;

namespace API_PowerBI_AzureAD
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var authUri = "https://login.microsoftonline.com/devscope365.onmicrosoft.com/oauth2/authorize";
                //"https://login.windows.net";
            //"https://login.microsoftonline.com/09e251dc-5e87-48bf-b4d2-71b01adb984a/oauth2/v2.0/token";
            // //"https://login.microsoftonline.com/devscope365.onmicrosoft.com/oauth2/authorize";

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                    TokenValidationParameters = new TokenValidationParameters {
                        ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
                    },
                    Provider = new OAuthBearerAuthenticationProvider {
                        OnApplyChallenge = async (context) => {
                            context.OwinContext.Response.Headers.Add("WWW-Authenticate", new string[1] { $"Bearer authorization_uri=\"{authUri}\"" });
                        },
                        OnValidateIdentity = async (context) => {
                            //System.Diagnostics.Debugger.Launch();
                            //var authUserId = context.OwinContext.Authentication.User.Claims
                            //    .FirstOrDefault(c => c.Type.Equals("upn?!"));
                        }
                    },
                });


        }
    }
}
