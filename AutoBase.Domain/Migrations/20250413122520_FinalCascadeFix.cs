using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoBase.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FinalCascadeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "TripReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "TripReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "FuelUsedLiters",
                table: "TripReports",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessful",
                table: "TripReports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "TripReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TripReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RideId",
                table: "TripReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ArivalTime",
                table: "Rides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "Rides",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Rides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Rides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Rides",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Rides",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Rides",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "RequestId",
                table: "Rides",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ArivalTime",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CarCategoryId",
                table: "Requests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PassengersCount",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Drivers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CarCategoryId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SeatsCount",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CarCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TripReports_RideId",
                table: "TripReports",
                column: "RideId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_CarId",
                table: "Rides",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_DriverId",
                table: "Rides",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_RequestId",
                table: "Rides",
                column: "RequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CarCategoryId",
                table: "Requests",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarCategoryId",
                table: "Cars",
                column: "CarCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverId",
                table: "Cars",
                column: "DriverId",
                unique: true,
                filter: "[DriverId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarCategory_CarCategoryId",
                table: "Cars",
                column: "CarCategoryId",
                principalTable: "CarCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Drivers_DriverId",
                table: "Cars",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CarCategory_CarCategoryId",
                table: "Requests",
                column: "CarCategoryId",
                principalTable: "CarCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Drivers_DriverId",
                table: "Rides",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Requests_RequestId",
                table: "Rides",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TripReports_Rides_RideId",
                table: "TripReports",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRole_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarCategory_CarCategoryId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Drivers_DriverId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CarCategory_CarCategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Cars_CarId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Drivers_DriverId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Requests_RequestId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_TripReports_Rides_RideId",
                table: "TripReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRole_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "CarCategory");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TripReports_RideId",
                table: "TripReports");

            migrationBuilder.DropIndex(
                name: "IX_Rides_CarId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_DriverId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_RequestId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CarCategoryId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarCategoryId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DriverId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "FuelUsedLiters",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "IsSuccessful",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "TripReports");

            migrationBuilder.DropColumn(
                name: "ArivalTime",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "Rides");

            migrationBuilder.DropColumn(
                name: "ArivalTime",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CarCategoryId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "PassengersCount",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CarCategoryId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SeatsCount",
                table: "Cars");
        }
    }
}
