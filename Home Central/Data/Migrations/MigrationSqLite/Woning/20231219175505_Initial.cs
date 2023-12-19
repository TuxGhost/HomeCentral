using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Home_Central.Data.Migrations.MigrationSqLite.Woning
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WoningVerbruik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GasStand = table.Column<int>(type: "INTEGER", nullable: false),
                    DagTeller = table.Column<int>(type: "INTEGER", nullable: false),
                    NachtTeller = table.Column<int>(type: "INTEGER", nullable: false),
                    Zon = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoningVerbruik", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WoningVerbruik");
        }
    }
}
