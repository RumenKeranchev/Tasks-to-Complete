﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBlog.Data.Blog
{
	public class BlogEntry
	{
		public int Id { get; set; }

		[ MinLength( 5 ) ]
		[ MaxLength( 50 ) ]
		public string Title { get; set; }

		[ MinLength( 10 ) ]
		public string Content { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.UtcNow;

		public IEnumerable<Comment> Comments { get; set; } = new List< Comment >();

		public int Likes { get; set; }
	}
}