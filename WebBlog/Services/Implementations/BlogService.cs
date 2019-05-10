using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WebBlog.Data;
using WebBlog.Data.Blog;
using WebBlog.Models.Blogs;
using WebBlog.Services.Interfaces;

namespace WebBlog.Services.Implementations
{
	public class BlogService : IBlogService
	{
		private readonly WebBlogDbContext db;

		public BlogService( WebBlogDbContext db )
		{
			this.db = db;
		}

		public IEnumerable< BlogEntry > All()
		{
			return this.db.BlogEntries
				.FromSql( "ReturnAllBlogEntries" )
				.ToList();
		}

		public void Create( CreateViewModel model )
		{
			this.db.Database
				.ExecuteSqlCommand( $"EXECUTE dbo.CreateBlogEntry @p0, @p1, @p2",
					parameters: new[]
					{
						model.Title,
						model.Content,
						model.UserId
					} );

			this.db.SaveChanges();
		}

		public void Like( int blogId )
		{
			this.db.Database
				.ExecuteSqlCommand( "EXECUTE dbo.[AddLike] @p0", parameters: blogId );

			this.db.SaveChanges();
		}

		public BlogWithCommentsViewModel BlogWithComments( int id )
		{
			var jsonResult = this.db.JsonResults
				.FromSql( "exec [dbo].[WPT2WB_GetBlogEntryInformation_JSON] {0}", id )
				.FirstOrDefault()
				.JSON_Result;

			if ( jsonResult.EndsWith( "\"Comments\": " ) )
			{
				jsonResult += "[] }]";
			}

			var deserialized = JsonConvert.DeserializeObject< BlogWithCommentsViewModel[] >( jsonResult );

			return deserialized[ 0 ];
		}

		public void AddComment( AddCommentViewModel model )
		{
			this.db.Database
				.ExecuteSqlCommand( "EXECUTE [dbo].[AddCommentToBlogEntry] @p0, @p1, @p2",
					parameters: new object[]
					{
						model.Content,
						model.BlogId,
						model.UserId
					} );

			this.db.SaveChanges();
		}
	}
}