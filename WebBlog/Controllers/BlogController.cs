﻿using System.Threading.Tasks;
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
		public async Task< IActionResult > Index()
		{
			var blogs = await this.blogService.All();

			return View( new BlogViewModel()
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
		public IActionResult Post( CreateViewModel model )
		{
			model.UserId = this.userManager.GetUserId( this.HttpContext.User );

			this.blogService.Create( model );

			return this.RedirectToAction( "Index" );
		}
	}
}