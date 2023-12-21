using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewTaskyAPI.Server.Migrations
{
    public partial class ProductGoalChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CurrentGoal",
                table: "ProductGoals",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal_1",
                table: "ProductGoals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal_2",
                table: "ProductGoals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal_3",
                table: "ProductGoals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal_4",
                table: "ProductGoals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Goal_5",
                table: "ProductGoals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentGoal",
                table: "ProductGoals");

            migrationBuilder.DropColumn(
                name: "Goal_1",
                table: "ProductGoals");

            migrationBuilder.DropColumn(
                name: "Goal_2",
                table: "ProductGoals");

            migrationBuilder.DropColumn(
                name: "Goal_3",
                table: "ProductGoals");

            migrationBuilder.DropColumn(
                name: "Goal_4",
                table: "ProductGoals");

            migrationBuilder.DropColumn(
                name: "Goal_5",
                table: "ProductGoals");
        }
    }
}
