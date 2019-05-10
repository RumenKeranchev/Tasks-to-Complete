namespace WebBlog.Models.Blogs
{
	public class AddCommentViewModel
	{
		public string Content { get; set; }

		public int BlogId { get; set; }

		public string UserId { get; set; }
	}
}