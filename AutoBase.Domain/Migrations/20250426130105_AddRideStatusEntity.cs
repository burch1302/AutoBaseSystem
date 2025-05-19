using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBase.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddRideStatusEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArivalTime",
                table: "Rides",
                newName: "ArrivalTime");

            migrationBuilder.AddColumn<Guid>(
                name: "RideStatusId",
                table: "Rides",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "RideStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rides_RideStatusId",
                table: "Rides",
                column: "RideStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_RideStatuses_RideStatusId",
                table: "Rides",
                column: "RideStatusId",
                principalTable: "RideStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_RideStatuses_RideStatusId",
                table: "Rides");

            migrationBuilder.DropTable(
                name: "RideStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Rides_RideStatusId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "RideStatusId",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "ArrivalTime",
                table: "Rides",
                newName: "ArivalTime");
        }
    }
}
