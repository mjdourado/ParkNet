using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkNet.Migrations
{
    /// <inheritdoc />
    public partial class BrowserAsking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Out",
                table: "Outs",
                newName: "Left");

            migrationBuilder.RenameColumn(
                name: "In",
                table: "Ins",
                newName: "Enter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Left",
                table: "Outs",
                newName: "Out");

            migrationBuilder.RenameColumn(
                name: "Enter",
                table: "Ins",
                newName: "In");
        }
    }
}
