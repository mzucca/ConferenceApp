using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Security.Authentication;

namespace ReHub.Utilities.Tests
{
    public class TestHostFixture : IDisposable
    {
        public HttpClient Client { get; }
        public IServiceProvider ServiceProvider { get; }

        public TestHostFixture()
        {
            var builder = CreateHostBuilder([])
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseEnvironment("Test");
                });
            var host = builder.Start();
            ServiceProvider = host.Services;
            Client = host.GetTestClient();
            Console.WriteLine("TEST Host Started.");
        }

        public void Dispose()
        {
            Client.Dispose();
            GC.SuppressFinalize(this);
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.ConfigureKestrel(serverOptions =>
                     {
                         serverOptions.Limits.MinRequestBodyDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                         serverOptions.Limits.MinResponseDataRate = new MinDataRate(100, TimeSpan.FromSeconds(10));
                         serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                         serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                         serverOptions.ConfigureHttpsDefaults(listenOptions =>
                         {
                             listenOptions.SslProtocols = SslProtocols.Tls12;
                         });
                     })
                         .UseStartup<Startup>();
                 });
    }
}
