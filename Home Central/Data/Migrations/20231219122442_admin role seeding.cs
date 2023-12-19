using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Central.Data.Migrations
{
    public partial class adminroleseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cadf322-9281-4f3b-aa8a-88d16dd7ff86", "4a941d24-579a-4364-a68f-8456269f56f4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc6b6de0-abd9-493c-9fc0-cf728261ab09",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb8319b8-0167-46c0-9f15-0206280833c7", "4c19d282-edd8-44d4-a187-85cd21be57c9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0cadf322-9281-4f3b-aa8a-88d16dd7ff86", "fc6b6de0-abd9-493c-9fc0-cf728261ab09" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0cadf322-9281-4f3b-aa8a-88d16dd7ff86", "fc6b6de0-abd9-493c-9fc0-cf728261ab09" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cadf322-9281-4f3b-aa8a-88d16dd7ff86");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fc6b6de0-abd9-493c-9fc0-cf728261ab09",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7fbeb77c-2e15-40e2-a592-372f205bf286", "8518e6e2-6e79-40ca-9846-7f789b410932" });
        }
    }
}
