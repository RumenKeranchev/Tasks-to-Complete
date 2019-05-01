using System.Collections.Generic;
using WebBlog.Data.Blog;

namespace WebBlog.Models.Blogs
{
	public class BlogViewModel
	{
		public IEnumerable< BlogEntry > BlogEntries { get; set; } = new List< BlogEntry >();
	}
}