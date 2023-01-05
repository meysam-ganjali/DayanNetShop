using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayanShop.Core.Migrations
{
    public partial class AddSumAmountToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_RequestPay_RequestPayId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetaile_Order_OrderId",
                table: "OrderDetaile");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetaile_Products_ProductId",
                table: "OrderDetaile");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestPay_AspNetUsers_UserId",
                table: "RequestPay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestPay",
                table: "RequestPay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetaile",
                table: "OrderDetaile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "RequestPay",
                newName: "RequestPays");

            migrationBuilder.RenameTable(
                name: "OrderDetaile",
                newName: "OrderDetailes");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_RequestPay_UserId",
                table: "RequestPays",
                newName: "IX_RequestPays_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetaile_ProductId",
                table: "OrderDetailes",
                newName: "IX_OrderDetailes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetaile_OrderId",
                table: "OrderDetailes",
                newName: "IX_OrderDetailes_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_RequestPayId",
                table: "Orders",
                newName: "IX_Orders_RequestPayId");

            migrationBuilder.AddColumn<long>(
                name: "SumAmount",
                table: "Carts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestPays",
                table: "RequestPays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetailes",
                table: "OrderDetailes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailes_Orders_OrderId",
                table: "OrderDetailes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetailes_Products_ProductId",
                table: "OrderDetailes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_RequestPays_RequestPayId",
                table: "Orders",
                column: "RequestPayId",
                principalTable: "RequestPays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestPays_AspNetUsers_UserId",
                table: "RequestPays",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailes_Orders_OrderId",
                table: "OrderDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetailes_Products_ProductId",
                table: "OrderDetailes");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_RequestPays_RequestPayId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestPays_AspNetUsers_UserId",
                table: "RequestPays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestPays",
                table: "RequestPays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetailes",
                table: "OrderDetailes");

            migrationBuilder.DropColumn(
                name: "SumAmount",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "RequestPays",
                newName: "RequestPay");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetailes",
                newName: "OrderDetaile");

            migrationBuilder.RenameIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPay",
                newName: "IX_RequestPay_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RequestPayId",
                table: "Order",
                newName: "IX_Order_RequestPayId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailes_ProductId",
                table: "OrderDetaile",
                newName: "IX_OrderDetaile_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetailes_OrderId",
                table: "OrderDetaile",
                newName: "IX_OrderDetaile_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestPay",
                table: "RequestPay",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetaile",
                table: "OrderDetaile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_RequestPay_RequestPayId",
                table: "Order",
                column: "RequestPayId",
                principalTable: "RequestPay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetaile_Order_OrderId",
                table: "OrderDetaile",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetaile_Products_ProductId",
                table: "OrderDetaile",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestPay_AspNetUsers_UserId",
                table: "RequestPay",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
