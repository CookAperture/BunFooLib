using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foos.Api.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FooCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooCategories", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RecommendedAmountPerDayEntries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MeasurementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendedAmountPerDayEntries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecommendedAmountPerDayEntries_Measurements_MeasurementID",
                        column: x => x.MeasurementID,
                        principalTable: "Measurements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    RecommendedAmountPerDayID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foos_FooCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "FooCategories",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Foos_RecommendedAmountPerDayEntries_RecommendedAmountPerDayID",
                        column: x => x.RecommendedAmountPerDayID,
                        principalTable: "RecommendedAmountPerDayEntries",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Foos_CategoryID",
                table: "Foos",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Foos_RecommendedAmountPerDayID",
                table: "Foos",
                column: "RecommendedAmountPerDayID");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendedAmountPerDayEntries_MeasurementID",
                table: "RecommendedAmountPerDayEntries",
                column: "MeasurementID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foos");

            migrationBuilder.DropTable(
                name: "FooCategories");

            migrationBuilder.DropTable(
                name: "RecommendedAmountPerDayEntries");

            migrationBuilder.DropTable(
                name: "Measurements");
        }
    }
}
