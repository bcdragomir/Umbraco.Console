
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common;
using UmbracoTools;
using UmbracoTools.Syncs;

public class Program
{

    public static void Run(MemberSync memberSync, CustomerSync customerSync)
    {
        memberSync.Start();
        customerSync.Start();
    }

    public static void Main(string[] args)
    {

        //these are required to create an environment to run the umbraco services via dependency injection
        var app = CreateHostBuilder(args)
            .Build();

        using (var serviceScope = app.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;
            app.Start();

            var factory = services.GetRequiredService<IUmbracoContextFactory>();
            using (factory.EnsureUmbracoContext())
            {
                //create the services
                var memberSync = services.GetRequiredService<MemberSync>();
                var customerSync = services.GetRequiredService<CustomerSync>();
                Run(memberSync,customerSync);
            }
        }

    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostbuilder = Host.CreateDefaultBuilder(args)
                .ConfigureUmbracoDefaults()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        return hostbuilder;
    }

}