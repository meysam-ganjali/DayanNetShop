using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanShop.Core.Migrations
{
    public partial class UpdateChildFild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParentTitleSlug",
                table: "ChildCategories",
                newName: "ChildTitleSlug");

            migrationBuilder.RenameColumn(
                name: "ParentTitle",
                table: "ChildCategories",
                newName: "ChildTitle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChildTitleSlug",
                table: "ChildCategories",
                newName: "ParentTitleSlug");

            migrationBuilder.RenameColumn(
                name: "ChildTitle",
                table: "ChildCategories",
                newName: "ParentTitle");
        }
    }
}
