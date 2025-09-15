using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuiceGo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addMaxLengthOfCategoryToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "JuiceGo_Categories",
                newName: "CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "JuiceGo_Categories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "JuiceGo_Categories",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryName",
                table: "JuiceGo_Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
