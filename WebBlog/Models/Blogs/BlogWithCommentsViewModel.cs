using System;

namespace WebBlog.Models.Blogs
{
	public class BlogWithCommentsViewModel
	{
		public Entry BlogEntry { get; set; }

		public Comments[] Comments { get; set; }

		public AddCommentViewModel AddComments{ get; set; }
	}

	public class Entry
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public DateTime CreationDate { get; set; }

		public int Likes { get; set; }
	}

	public class Comments
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public int BlogId { get; set; }
	}
}