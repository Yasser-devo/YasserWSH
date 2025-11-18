using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YasserWorkShop.Migrations
{
    /// <inheritdoc />
    public partial class updateEployerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "employers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Descripton",
                table: "employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMail",
                table: "employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "employers",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripton",
                table: "employers");

            migrationBuilder.DropColumn(
                name: "EMail",
                table: "employers");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "employers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "employers");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "employers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
