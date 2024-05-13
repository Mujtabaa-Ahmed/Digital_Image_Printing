using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyImage.Migrations
{
    public partial class addedservicestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    service_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    service_price = table.Column<int>(type: "int", nullable: false),
                    service_cancledprice = table.Column<int>(type: "int", nullable: false),
                    service_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cat_id = table.Column<int>(type: "int", nullable: false),
                    subCat_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.service_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
