using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SMH60Store.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ShoppingCart",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreditCard", "Email", "FirstName", "LastName", "PhoneNumber", "Province" },
                values: new object[,]
                {
                    { 1, "1234567890123456", "schmingbing@gmail.com", "Schmingus", "McBingus", "1234567890", "QC" },
                    { 2, "1234567890123456", "oingboing@gmail.com", "Oingus", "Boingus", "1234567890", "NS" },
                    { 3, "1234567890123456", "QuandaleDingle@gmail.com", "Quandale", "Dingle", "1234567890", "BC" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "CustomerId", "DateCreated", "DateFufilled", "Taxes", "Total" },
                values: new object[] { 1, 3, new DateTime(2026, 9, 22, 22, 57, 23, 854, DateTimeKind.Local).AddTicks(7651), new DateTime(2026, 9, 22, 22, 57, 23, 854, DateTimeKind.Local).AddTicks(7655), 0m, 0m });

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "ShoppingCartID", "CustomerId", "DateCreated" },
                values: new object[] { 1, 1, new DateTime(2026, 9, 22, 22, 57, 23, 854, DateTimeKind.Local).AddTicks(7542) });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartItemId", "Price", "ProductId", "Quantity", "ShoppingCartID" },
                values: new object[,]
                {
                    { 1, 25.00m, 3, 1, 1 },
                    { 2, 780.00m, 2, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderItemId", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 25.00m, 3, 1 },
                    { 2, 1, 80.00m, 4, 1 },
                    { 3, 1, 40.00m, 6, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "CartItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumn: "CartItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCart",
                keyColumn: "ShoppingCartID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "ShoppingCart",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
