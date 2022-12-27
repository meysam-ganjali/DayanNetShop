using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanShop.Core.Migrations
{
    public partial class CreateCategoryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentTitleSlug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    ParentTitleSlug = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ParentCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildCategories");

            migrationBuilder.DropTable(
                name: "ParentCategories");
        }
    }
}
