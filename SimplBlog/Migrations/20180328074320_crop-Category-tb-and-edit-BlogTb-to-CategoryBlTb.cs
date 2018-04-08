using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimplBlog.Migrations
{
    public partial class cropCategorytbandeditBlogTbtoCategoryBlTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Posts",
                newName: "CateBlId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                newName: "IX_Posts_CateBlId");

            migrationBuilder.CreateTable(
                name: "CategoryBls",
                columns: table => new
                {
                    CateBlId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBls", x => x.CateBlId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_CategoryBls_CateBlId",
                table: "Posts",
                column: "CateBlId",
                principalTable: "CategoryBls",
                principalColumn: "CateBlId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_CategoryBls_CateBlId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "CategoryBls");

            migrationBuilder.RenameColumn(
                name: "CateBlId",
                table: "Posts",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CateBlId",
                table: "Posts",
                newName: "IX_Posts_BlogId");

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlogId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_BlogId",
                table: "Category",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Blogs_BlogId",
                table: "Posts",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
