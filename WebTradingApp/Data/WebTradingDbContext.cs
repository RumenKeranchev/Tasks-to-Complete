using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebTradingApp.Data
{
	public class WebTradingDbContext : IdentityDbContext
	{
		public WebTradingDbContext(DbContextOptions<WebTradingDbContext> options)
			: base(options)
		{
		}
	}
}
