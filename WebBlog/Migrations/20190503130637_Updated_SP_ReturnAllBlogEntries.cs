using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
    public partial class Updated_SP_ReturnAllBlogEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        var sp = @"USE WebProjects_Task02_WebBlog;
							  GO
							  CREATE PROCEDURE dbo.ReturnAllBlogEntries
							  AS
							  SELECT * FROM WebProjects_Task02_WebBlog.dbo.BlogEntries
							  GO";

	        migrationBuilder.Sql( sp );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
