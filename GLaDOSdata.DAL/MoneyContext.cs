using System;
using GLaDOSdata.DAL.Models.Items;
using Microsoft.EntityFrameworkCore;
namespace GLaDOSdata.DAL
{
	public class MoneyContext : DbContext
	{
		public MoneyContext(DbContextOptions<MoneyContext> options) : base(options) { }

		public DbSet<Item> Items { get; set; }
	}
}

