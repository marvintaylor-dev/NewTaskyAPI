using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewTaskyAPI.Server.Migrations
{
    public partial class changeDueDateToEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Tasks",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Tasks",
                newName: "DueDate");
        }
    }
}
