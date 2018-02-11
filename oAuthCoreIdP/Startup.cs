using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer4.Validation;
using IdentityServer4.Models;
using IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;

namespace oAuthCoreIdP
{
    public class SecretValidator : ISecretValidator
    {
        public Task<SecretValidationResult> ValidateAsync(IEnumerable<Secret> secrets, ParsedSecret parsedSecret)
        {
            return Task.FromResult(new SecretValidationResult() { Success = true });
        }
    }
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static readonly string AuthScheme = IdentityServerConstants.DefaultCookieAuthenticationScheme; //"bearer";

        public void ConfigureServices(IServiceCollection services)
        {
            //Grab key for verifying JWT signature
            //In prod, we'd get this from the certificate store or similar
            var certPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "TestSign.pfx");
            var cert = new X509Certificate2(certPath, "111111"); 

            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer(options => //.AddDeveloperIdentityServer
                {
                    options.IssuerUri = "http://localhost:5000";
                    //options.Authentication.AuthenticationScheme = AuthScheme;
                }) //.AddInMemoryIdentityResources(Scopes.Get())
                .AddInMemoryApiResources(Scopes.GetApi())//.AddInMemoryScopes(Scopes.Get())
                .AddInMemoryClients(Clients.Get()).AddTestUsers(Users.GetTest())
                //.AddInMemoryUsers(Users.Get())
                .AddSigningCredential(cert) //.SetSigningCredential(cert)
                .AddSecretValidator<SecretValidator>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
