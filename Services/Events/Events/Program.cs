using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Events.WEBAPI
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();

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
                    }); ;
                });
    }
}
