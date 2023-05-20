// See https://aka.ms/new-console-template for more information
using GLaDos_Discord_Bot;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace GLaDos_Discord_Bot
{
    class Program
    {

        static void Main(string[] args)
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
}








/*Console.WriteLine("Hello, World!");

var bot = new Bot();
bot.RunAsync().GetAwaiter().GetResult();*/