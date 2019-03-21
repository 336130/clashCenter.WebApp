using System;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin;
using clashCenter.Providers;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(clashCenter.Startup))]

namespace clashCenter
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                Provider = new SimpleAuthorizationProvider()
            };
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());


            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
