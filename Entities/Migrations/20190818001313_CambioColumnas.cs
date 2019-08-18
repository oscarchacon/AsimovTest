using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class CambioColumnas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "DeathDate",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "DeathDate",
                newName: "End");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "DeathDate",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "DeathDate",
                newName: "EndDate");
        }
    }
}
