using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Data.Migrations
{
    public partial class addedcheckedInKidsAndAdults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "BreakfastOrders");

            migrationBuilder.AddColumn<int>(
                name: "AdultsCheckedIn",
                table: "BreakfastOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KidsCheckedIn",
                table: "BreakfastOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdultsCheckedIn",
                table: "BreakfastOrders");

            migrationBuilder.DropColumn(
                name: "KidsCheckedIn",
                table: "BreakfastOrders");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "BreakfastOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
