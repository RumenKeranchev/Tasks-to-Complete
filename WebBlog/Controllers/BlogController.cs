using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Data;
using WebBlog.Models.Blogs;
using WebBlog.Services.Interfaces;

namespace WebBlog.Controllers
{
	public class BlogController : Controller
	{
		private readonly IBlogService blogService;

		private readonly UserManager< User > userManager;

		public BlogController( IBlogService blogService, UserManager< User > userManager )
		{
			this.blogService = blogService;
			this.userManager = userManager;
		}

		// GET
		public IActionResult Index()
		{
			var blogs = this.blogService.All();

			return this.View( new BlogViewModel()
			{
				BlogEntries = blogs
			} );
		}

		[ Authorize ]
		public IActionResult Create()
		{
			return this.View();
		}

		[ Authorize ]
		[ HttpPost ]
		public IActionResult Post( CreateViewModel model )
		{
			model.UserId = this.userManager.GetUserId( this.HttpContext.User );

			this.blogService.Create( model );

			return this.RedirectToAction( "Index" );
		}

		[ Authorize ]
		public IActionResult Like( int blogId )
		{
			this.blogService.Like( blogId );

			return this.RedirectToAction( "Index" );
		}

		public IActionResult Blog( int id )
		{
			var blog = this.blogService.BlogWithComments( id );

			return this.View( blog );
		}

		[ Authorize ]
		[ HttpPost ]
		public IActionResult AddComment( BlogWithCommentsViewModel model )
		{
			model.AddComments.UserId = this.userManager.GetUserId(this.HttpContext.User);

			this.blogService.AddComment( model.AddComments );

			return this.RedirectToAction( "Blog", new { id = model.AddComments.BlogId } );
		}

		//todo: User can like a post once
		//todo: propper UI
	}
}