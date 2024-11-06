using Microsoft.AspNetCore.Server.Kestrel.Core;
using Events.WEBAPI.Extensions;
using Events.DAL;
namespace Events.WEBAPI
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build()
            .MigrateDatabase<EventContext>()
            .Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.ConfigureEndpointDefaults(listenOptions =>
                        {
                            listenOptions.Protocols = HttpProtocols.Http1AndHttp2; 
                        });
                    }); 
                });
    }
}
