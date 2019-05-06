using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
	public partial class Added_SP_AddLike : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			var sp = @"USE WebProjects_Task02_WebBlog
							  GO
							  CREATE PROCEDURE dbo.AddLike
							  	@BlogId INT
							  AS
							  BEGIN
							  UPDATE WebProjects_Task02_WebBlog.dbo.BlogEntries
							  SET Likes += 1
							  WHERE Id = @BlogId
							  END";

			migrationBuilder.Sql( sp );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
		}
	}
}