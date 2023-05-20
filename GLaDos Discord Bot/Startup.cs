using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
namespace GLaDos_Discord_Bot
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			var serviceProvider = services.BuildServiceProvider();

			var bot = new Bot(serviceProvider);
			services.AddSingleton(bot);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{

		}
	}
}

