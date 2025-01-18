using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.Services;
using OnlineShop.Infrastructure.Interfaces;
using OnlineShop.Infrastructure.Repositories;
using OnlineShop.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Web;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
