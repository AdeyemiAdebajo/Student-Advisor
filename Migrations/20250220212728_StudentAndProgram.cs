using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentAdvisor.Migrations
{
    /// <inheritdoc />
    public partial class StudentAndProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60d8e1f9-1df7-4507-b23c-dd687c7bac1a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fccf05ac-6db8-4886-a282-54c618d40563");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c58fbbd-57aa-4cda-b5c1-3bedb9b566c8", null, "admin", "admin" },
                    { "16347b1b-9a67-4097-a709-a8a156104455", null, "client", "client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c58fbbd-57aa-4cda-b5c1-3bedb9b566c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16347b1b-9a67-4097-a709-a8a156104455");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "60d8e1f9-1df7-4507-b23c-dd687c7bac1a", null, "admin", "admin" },
                    { "fccf05ac-6db8-4886-a282-54c618d40563", null, "client", "client" }
                });
        }
    }
}
