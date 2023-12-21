using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewTaskyAPI.Server.Migrations
{
    public partial class addHeightValueToEstimates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisualHeight",
                table: "RelativeEstimates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisualHeight",
                table: "RelativeEstimates");
        }
    }
}
