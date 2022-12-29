using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanShop.Core.Migrations
{
    public partial class CreateCategoryAtrributeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildCategoryId = table.Column<int>(type: "int", nullable: false),
                    AttributeTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryAttributes_ChildCategories_ChildCategoryId",
                        column: x => x.ChildCategoryId,
                        principalTable: "ChildCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributes_ChildCategoryId",
                table: "CategoryAttributes",
                column: "ChildCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryAttributes");
        }
    }
}
