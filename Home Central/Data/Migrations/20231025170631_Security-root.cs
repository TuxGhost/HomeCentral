using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Central.Data.Migrations
{
    public partial class Securityroot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fc6b6de0-abd9-493c-9fc0-cf728261ab09", 0, "7fbeb77c-2e15-40e2-a592-372f205bf286", "root@localhost", true, false, null, "ROOT@localhost", "ROOT@LOCALHOST", "AQAAAAEAACcQAAAAECGCcqKC8uTLYFmkqXuCTiHuuvy+7qi1AVr7/dP+GsNXcUTYbfRXeGJKQ4fEcqtszQ==", null, false, "8518e6e2-6e79-40ca-9846-7f789b410932", false, "root@localhost" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc6b6de0-abd9-493c-9fc0-cf728261ab09");
        }
    }
}
