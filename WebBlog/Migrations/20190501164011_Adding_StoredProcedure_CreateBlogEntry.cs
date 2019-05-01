using Microsoft.EntityFrameworkCore.Migrations;

namespace WebBlog.Migrations
{
	public partial class Adding_StoredProcedure_CreateBlogEntry : Migration
	{
		protected override void Up( MigrationBuilder migrationBuilder )
		{
			var sp = @"USE WebProjects_Task02_WebBlog;
							  GO
							  CREATE procedure CreateBlogEntry
							  	@Title varchar(100),
							  	@Content varchar(max),
							  	@CreationDate datetime,
							  	@UserId nvarchar(450)
							  AS
							  	INSERT INTO BlogEntries(Title,Content, CreationDate, UserId)
							  	VALUES (@Title, @Content, @CreationDate, @UserId)
							 GO";

			migrationBuilder.Sql( sp );
		}

		protected override void Down( MigrationBuilder migrationBuilder )
		{
		}
	}
}