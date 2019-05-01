using System.Collections.Generic;
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
			this.db.BlogEntries.FromSql(
				$"CreateBlogEntry {model.Title}, {model.Content}, {model.CreationDate}, {model.UserId}" );

			this.db.SaveChanges();
		}
	}
}