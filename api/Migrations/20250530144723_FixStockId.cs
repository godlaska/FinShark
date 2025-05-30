using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class FixStockId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e86b8de-efc8-41f5-9ecf-ce11d0fab2e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83e15e91-9832-43f1-996b-b4fd00e92dd1");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d833b11-4c0a-44f1-b2f1-3210d447cb07", null, "User", "USER" },
                    { "7d3afde9-5b9f-4a38-a001-6cd80cc9a597", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d833b11-4c0a-44f1-b2f1-3210d447cb07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d3afde9-5b9f-4a38-a001-6cd80cc9a597");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Ratings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e86b8de-efc8-41f5-9ecf-ce11d0fab2e2", null, "User", "USER" },
                    { "83e15e91-9832-43f1-996b-b4fd00e92dd1", null, "Admin", "ADMIN" }
                });
        }
    }
}
