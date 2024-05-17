using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkoButik_Client.Migrations
{
    /// <inheritdoc />
    public partial class FixedOrderComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrdersOrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductsProductId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrdersOrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductsProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "OrdersOrderId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FkOrderId",
                table: "OrderItems",
                column: "FkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FkProductId",
                table: "OrderItems",
                column: "FkProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_FkOrderId",
                table: "OrderItems",
                column: "FkOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_FkProductId",
                table: "OrderItems",
                column: "FkProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_FkOrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_FkProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_FkOrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_FkProductId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "OrdersOrderId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrdersOrderId",
                table: "OrderItems",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductsProductId",
                table: "OrderItems",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrdersOrderId",
                table: "OrderItems",
                column: "OrdersOrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductsProductId",
                table: "OrderItems",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
