using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Foos.Api.Database.Migrations
{
    public partial class RequiredAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foos_FooCategories_CategoryID",
                table: "Foos");

            migrationBuilder.DropForeignKey(
                name: "FK_Foos_RecommendedAmountPerDayEntries_RecommendedAmountPerDayID",
                table: "Foos");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RecommendedAmountPerDayEntries",
                newName: "Amount");

            migrationBuilder.AlterColumn<int>(
                name: "RecommendedAmountPerDayID",
                table: "Foos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Foos",
                keyColumn: "Name",
                keyValue: null,
                column: "Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Foos",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Foos",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Foos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Foos_FooCategories_CategoryID",
                table: "Foos",
                column: "CategoryID",
                principalTable: "FooCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foos_RecommendedAmountPerDayEntries_RecommendedAmountPerDayID",
                table: "Foos",
                column: "RecommendedAmountPerDayID",
                principalTable: "RecommendedAmountPerDayEntries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foos_FooCategories_CategoryID",
                table: "Foos");

            migrationBuilder.DropForeignKey(
                name: "FK_Foos_RecommendedAmountPerDayEntries_RecommendedAmountPerDayID",
                table: "Foos");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "RecommendedAmountPerDayEntries",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "RecommendedAmountPerDayID",
                table: "Foos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Foos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Foos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Foos_FooCategories_CategoryID",
                table: "Foos",
                column: "CategoryID",
                principalTable: "FooCategories",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Foos_RecommendedAmountPerDayEntries_RecommendedAmountPerDayID",
                table: "Foos",
                column: "RecommendedAmountPerDayID",
                principalTable: "RecommendedAmountPerDayEntries",
                principalColumn: "ID");
        }
    }
}
