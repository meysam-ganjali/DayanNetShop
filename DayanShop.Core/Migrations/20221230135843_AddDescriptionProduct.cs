using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanShop.Core.Migrations
{
    public partial class AddDescriptionProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributes_ChildCategories_ChildCategoryId",
                table: "CategoryAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_CategoryAttributes_CategoryAttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviws_Products_ProductId",
                table: "ProductReviws");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributes_ChildCategories_ChildCategoryId",
                table: "CategoryAttributes",
                column: "ChildCategoryId",
                principalTable: "ChildCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId",
                principalTable: "ParentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_CategoryAttributes_CategoryAttributeId",
                table: "ProductAttributes",
                column: "CategoryAttributeId",
                principalTable: "CategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviws_Products_ProductId",
                table: "ProductReviws",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId",
                principalTable: "ChildCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributes_ChildCategories_ChildCategoryId",
                table: "CategoryAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_CategoryAttributes_CategoryAttributeId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductReviws_Products_ProductId",
                table: "ProductReviws");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributes_ChildCategories_ChildCategoryId",
                table: "CategoryAttributes",
                column: "ChildCategoryId",
                principalTable: "ChildCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChildCategories_ParentCategories_ParentCategoryId",
                table: "ChildCategories",
                column: "ParentCategoryId",
                principalTable: "ParentCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_CategoryAttributes_CategoryAttributeId",
                table: "ProductAttributes",
                column: "CategoryAttributeId",
                principalTable: "CategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_Products_ProductId",
                table: "ProductAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductReviws_Products_ProductId",
                table: "ProductReviws",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ChildCategories_ChildCategoryId",
                table: "Products",
                column: "ChildCategoryId",
                principalTable: "ChildCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
