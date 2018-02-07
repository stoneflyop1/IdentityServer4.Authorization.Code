using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using IdentityServer3.Core;
using IdentityServer3.Core.Configuration;
using IdentityModel.Client;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Services.Default;

[assembly: OwinStartup(typeof(oAuthCoreIdP.Startup))]

namespace oAuthCoreIdP
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // todo: replace with serilog
            //LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            AntiForgeryConfig.UniqueClaimTypeIdentifier = Constants.ClaimTypes.Subject;
            //JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            var fac = new IdentityServerServiceFactory()
                                .UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get());

            app.UseIdentityServer(new IdentityServerOptions
            {
                RequireSsl = false,
                SiteName = "Embedded IdentityServer",
                SigningCertificate = LoadCertificate(),
                Factory = fac,
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });
        }

        X509Certificate2 LoadCertificate()
        {
            var cer = System.IO.Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "TestSign.pfx");
            return new X509Certificate2(cer, "111111");
        }
    }
}