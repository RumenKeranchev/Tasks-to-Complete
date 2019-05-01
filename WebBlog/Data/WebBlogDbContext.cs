using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebBlog.Data
{
	public class WebBlogDbContext : IdentityDbContext
	{
		public DbSet< BlogEntry > BlogEntries { get; set; }

		public WebBlogDbContext( DbContextOptions< WebBlogDbContext > options )
			: base( options )
		{
		}

		protected override void OnModelCreating( ModelBuilder builder )
		{
			builder
				.Entity< BlogEntry >()
				.HasOne( be => be.User )
				.WithMany( u => u.BlogEntries )
				.HasForeignKey( be => be.UserId );

			base.OnModelCreating( builder );
		}
	}
}