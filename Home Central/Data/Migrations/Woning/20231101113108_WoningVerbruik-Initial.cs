using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Home_Central.Data.Migrations.Woning
{
    public partial class WoningVerbruikInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WoningVerbruik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GasStand = table.Column<int>(type: "int", nullable: false),
                    DagTeller = table.Column<int>(type: "int", nullable: false),
                    NachtTeller = table.Column<int>(type: "int", nullable: false),
                    Zon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoningVerbruik", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WoningVerbruik");
        }
    }
}
