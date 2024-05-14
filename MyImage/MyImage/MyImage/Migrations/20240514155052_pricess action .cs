using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyImage.Migrations
{
    public partial class pricessaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "service_cancledprice",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "service_price",
                table: "services",
                newName: "prices");

            migrationBuilder.AddColumn<string>(
                name: "service_image",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "prices",
                columns: table => new
                {
                    price_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prices = table.Column<int>(type: "int", nullable: false),
                    cancleed_prices = table.Column<int>(type: "int", nullable: false),
                    service_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prices", x => x.price_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prices");

            migrationBuilder.DropColumn(
                name: "service_image",
                table: "services");

            migrationBuilder.RenameColumn(
                name: "prices",
                table: "services",
                newName: "service_price");

            migrationBuilder.AddColumn<int>(
                name: "service_cancledprice",
                table: "services",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
