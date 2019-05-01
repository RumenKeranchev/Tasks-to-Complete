using System;
using System.ComponentModel.DataAnnotations;

namespace WebBlog.Data
{
	public class BlogEntry
	{
		public int Id { get; set; }

		[ MinLength( 5 ) ]
		[ MaxLength( 50 ) ]
		public string Title { get; set; }

		[ MinLength( 10 ) ]
		[ MaxLength( 500 ) ]
		public string Content { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public DateTime CreationDate { get; set; } = DateTime.UtcNow;
	}
}