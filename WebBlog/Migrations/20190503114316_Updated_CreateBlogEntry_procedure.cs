using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
    public partial class Updated_CreateBlogEntry_procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        var sp = @"USE WebProjects_Task02_WebBlog;
							  GO
							  CREATE PROCEDURE dbo.CreateBlogEntry
							  	@Title varchar(100),
							  	@Content varchar(max),
							  	@UserId nvarchar(450)
							  AS
							  	INSERT INTO WebProjects_Task02_WebBlog.dbo.BlogEntries(Title,Content, CreationDate, UserId)
							  	VALUES (@Title, @Content, GETDATE(), @UserId)
							 GO";

	        migrationBuilder.Sql(sp);

		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
