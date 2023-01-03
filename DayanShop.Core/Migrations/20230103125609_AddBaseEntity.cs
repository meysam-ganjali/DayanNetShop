using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanShop.Core.Migrations
{
    public partial class AddBaseEntity : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "ProductReviws",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductReviws",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "ProductAttributes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ProductAttributes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "ParentCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ParentCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "ChildCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "ChildCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "CategoryAttributes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "CategoryAttributes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "InsertDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ProductReviws");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductReviws");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ParentCategories");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "ChildCategories");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "CategoryAttributes");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "CategoryAttributes");

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
    }
}
