using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a93406f8-0f41-4a6a-9978-16295c5ff250", 0, "f3ce9989-8f39-4454-8411-19352334b9a2", "u@u1.com", true, false, null, "u@u1.com", "user1", null, null, false, "4b40f86d-d47d-4c0e-9862-6a4414b21ba5", false, "user1" });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a0fb49d8-6c05-4471-8bd5-94addbda612e", 0, "68d72b9b-9d4b-438f-a598-c22b4b75b603", "u@u2.com", true, false, null, "u@u2.com", "user2", null, null, false, "9a5da65e-2ca7-4fbe-a07f-c0a3704749f2", false, "user2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "a0fb49d8-6c05-4471-8bd5-94addbda612e");

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "a93406f8-0f41-4a6a-9978-16295c5ff250");
        }
    }
}
