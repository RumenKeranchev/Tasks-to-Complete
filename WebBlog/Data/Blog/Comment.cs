namespace WebBlog.Data.Blog
{
	public class Comment
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public string UserId { get; set; }

		public User User { get; set; }

		public int BlogId { get; set; }

		public BlogEntry BlogEntry { get; set; }
	}
}