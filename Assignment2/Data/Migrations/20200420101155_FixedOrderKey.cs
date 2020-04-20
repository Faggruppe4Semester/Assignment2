using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Data.Migrations
{
    public partial class FixedOrderKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_BreakfastOrders",
                table: "BreakfastOrders",
                columns: new[] { "Date", "RoomNumber" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BreakfastOrders",
                table: "BreakfastOrders");
        }
    }
}
