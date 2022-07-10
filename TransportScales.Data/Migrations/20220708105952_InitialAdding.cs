using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportScales.Data.Migrations
{
    public partial class InitialAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Journal",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Journal",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Journal");
        }
    }
}
