using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HowsYourDayAPI.Migrations
{
    /// <inheritdoc />
    public partial class AccountManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d0d5de1-79db-45bb-bd9a-d8ddf38f4be5", null, "User", "USER" },
                    { "a6c27ef2-bb75-48f4-acb4-4264c3020a33", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d0d5de1-79db-45bb-bd9a-d8ddf38f4be5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6c27ef2-bb75-48f4-acb4-4264c3020a33");
        }
    }
}
