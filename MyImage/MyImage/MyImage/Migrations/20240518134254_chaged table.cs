using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyImage.Migrations
{
    public partial class chagedtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "service_id",
                table: "prices");

            migrationBuilder.RenameColumn(
                name: "prices",
                table: "services",
                newName: "size_id");

            migrationBuilder.AddColumn<int>(
                name: "price_id",
                table: "sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "service_id",
                table: "sizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price_id",
                table: "sizes");

            migrationBuilder.DropColumn(
                name: "service_id",
                table: "sizes");

            migrationBuilder.RenameColumn(
                name: "size_id",
                table: "services",
                newName: "prices");

            migrationBuilder.AddColumn<int>(
                name: "service_id",
                table: "prices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
