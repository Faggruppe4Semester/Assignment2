using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Data.Migrations
{
    public partial class AddedDBSetForOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakfastOrders",
                columns: table => new
                {
                    Date = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    AmountAdults = table.Column<int>(nullable: false),
                    AmountKids = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakfastOrders");
        }
    }
}
