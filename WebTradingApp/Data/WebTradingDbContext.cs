using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebTradingApp.Data.Models;

namespace WebTradingApp.Data
{
	public class WebTradingDbContext : IdentityDbContext
	{
		public DbSet<TradeItem> TradeItems { get; set; }

		public WebTradingDbContext(DbContextOptions<WebTradingDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating( ModelBuilder builder )
		{


			base.OnModelCreating( builder );
		}
	}
}
