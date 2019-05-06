using System.Collections.Generic;
using System.Threading.Tasks;
using WebBlog.Data.Blog;
using WebBlog.Models.Blogs;

namespace WebBlog.Services.Interfaces
{
	public interface IBlogService
	{
		 IEnumerable< BlogEntry > All();

		void Create(CreateViewModel model);

		void Like(int blogId);

		BlogWithCommentsViewModel BlogWithComments( int id );
	}
}