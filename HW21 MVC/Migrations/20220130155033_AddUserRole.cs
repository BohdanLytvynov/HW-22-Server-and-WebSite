using Microsoft.EntityFrameworkCore.Migrations;

namespace HW21_MVC.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a982c4d-b6d9-4fd6-9937-f67761feffe7",
                column: "ConcurrencyStamp",
                value: "8b2e3247-00dd-4ce1-84b4-895ee2bd9e6a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd326530-8a0a-4a88-bfac-d12a501810f4", "2a3dc6f4-d55c-4487-a72d-e8b47812faca", "user", "User" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "946574fd-bb30-462f-83a4-3a77fc0d8fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a64ffdc-81f4-4584-8f94-0e862bbe0eae", "AQAAAAEAACcQAAAAEGXB+BmLktj39kSbh+U8lgzU3nsNmnziI+he78IkSDKePI81lpZwYU3xy4Vc1q8J9A==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd326530-8a0a-4a88-bfac-d12a501810f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a982c4d-b6d9-4fd6-9937-f67761feffe7",
                column: "ConcurrencyStamp",
                value: "89f6162e-12cc-49e1-9c26-d2bbc29c19e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "946574fd-bb30-462f-83a4-3a77fc0d8fed",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2cdc2805-c7d4-45a1-be3e-9a615b73a126", "AQAAAAEAACcQAAAAEEYc8oJMPMQojevARTSsv5ioAeh37pXD7OsH5aEgfDlFiFJOtMlEXhgqZg6RJyga/g==" });
        }
    }
}
