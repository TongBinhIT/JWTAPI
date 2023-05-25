using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWTAPI.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModelArea",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArea = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelArea", x => x.IdArea);
                });
            migrationBuilder.DropTable("Area");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelArea");
        }
    }
}
