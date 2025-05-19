using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBase.Domain.Migrations
{
    /// <inheritdoc />
    public partial class RenameArivalTimeToArrivalTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArivalTime",
                table: "Requests",
                newName: "ArrivalTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Requests",
                newName: "ArivalTime");
        }
    }
}
