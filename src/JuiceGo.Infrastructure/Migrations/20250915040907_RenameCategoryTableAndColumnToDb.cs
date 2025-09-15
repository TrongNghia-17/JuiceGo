using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuiceGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCategoryTableAndColumnToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "JuiceGo_Categories");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "JuiceGo_Categories",
                newName: "CategoryName");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "JuiceGo_Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JuiceGo_Categories",
                table: "JuiceGo_Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_JuiceGo_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "JuiceGo_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_JuiceGo_Categories_CategoryId1",
                table: "Products",
                column: "CategoryId1",
                principalTable: "JuiceGo_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_JuiceGo_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_JuiceGo_Categories_CategoryId1",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JuiceGo_Categories",
                table: "JuiceGo_Categories");

            migrationBuilder.RenameTable(
                name: "JuiceGo_Categories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId1",
                table: "Products",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
