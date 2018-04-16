using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplBlog.Migrations
{
    public partial class spGetRecentPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetRecentPosts]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select top(3) *
					 from Posts 
					 where PostedOn < = GETDATE()
					  order by PostedOn Desc
                END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
