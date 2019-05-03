using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

		public async Task< IEnumerable< BlogEntry > > All()
		{
			return await this.db.BlogEntries
				.FromSql( "ReturnAllBlogEntriesWithoutComments" )
				.ToListAsync();
		}

		public void Create( CreateViewModel model )
		{
//			NOT WORKING!!!!
//			var query = "CreateBlogEntry #Title, #Content, UserId";
//
//			using ( var connection = ( SqlConnection ) this.db.Database.GetDbConnection() )
//			using ( var cmd = new SqlCommand( query, connection ) )
//			{
//				cmd.Parameters.AddWithValue( "#Title", model.Title );
//				cmd.Parameters.AddWithValue( "#Content", model.Content );
//				cmd.Parameters.AddWithValue( "#UserId", model.UserId );
//				connection.Open();
//				var a = cmd.ExecuteNonQuery();
//			}

			var a = this.db.BlogEntries.FromSql(
				$"CreateBlogEntry {model.Title}, {model.Content}, {model.UserId}" );

			this.db.SaveChanges();
		}
	}
}