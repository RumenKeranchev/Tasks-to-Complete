using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebBlog.Data.Blog;

namespace WebBlog.Data
{
	public class WebBlogDbContext : IdentityDbContext
	{
		public DbSet< BlogEntry > BlogEntries { get; set; }
		
		public DbSet< Comment > Comments { get; set; }

		public DbQuery<JsonResult> JsonResults { get; set; }

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

			builder
				.Entity< Comment >()
				.HasOne( c => c.BlogEntry )
				.WithMany( be => be.Comments )
				.HasForeignKey( c => c.BlogId );

			builder
				.Entity< Comment >()
				.HasOne( c => c.User )
				.WithMany( u => u.Comments )
				.HasForeignKey( c => c.UserId );

			base.OnModelCreating( builder );
		}
	}
}