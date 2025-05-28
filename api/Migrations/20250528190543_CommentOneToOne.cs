using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class CommentOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04c557fe-094f-4f7d-b514-e204640642b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "779e024d-4965-4372-a4d1-905193063afc");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5fb130ba-ab98-468f-921e-3fc448f511fb", null, "User", "USER" },
                    { "ea60ff86-841f-49fd-be73-91117bd3fe6f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fb130ba-ab98-468f-921e-3fc448f511fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea60ff86-841f-49fd-be73-91117bd3fe6f");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04c557fe-094f-4f7d-b514-e204640642b2", null, "User", "USER" },
                    { "779e024d-4965-4372-a4d1-905193063afc", null, "Admin", "ADMIN" }
                });
        }
    }
}
