using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
	public partial class Adding_StoredProcedure_ReturnAllBlogEntries : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			var sp = @"USE WebProjects_Task02_WebBlog;
							  GO
							  CREATE PROCEDURE ReturnAllBlogEntries
							  AS
							  SELECT be.Id, be.Title, be.Content, be.CreationDate, be.UserId, c.Content FROM BlogEntries be
							  JOIN Comments c 
							  ON c.BlogId = be.Id
							  GO";

			migrationBuilder.Sql( sp );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
		}
	}
}