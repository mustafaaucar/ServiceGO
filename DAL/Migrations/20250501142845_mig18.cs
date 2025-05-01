using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLocation",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EndCoordinats",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EveningStartHour",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MorningStartHour",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartCoordinats",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Passangers");

            migrationBuilder.RenameColumn(
                name: "PricePerKM",
                table: "Routes",
                newName: "PricePerKm");

            migrationBuilder.RenameColumn(
                name: "RouteID",
                table: "Passangers",
                newName: "RouteId");

            migrationBuilder.RenameColumn(
                name: "Coordinats",
                table: "Passangers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "IdentityCardPhoto",
                table: "Drivers",
                newName: "IdentityCardPhotoUrl");

            migrationBuilder.RenameColumn(
                name: "DriverCardPhoto",
                table: "Drivers",
                newName: "DriverCardPhotoUrl");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Drivers",
                newName: "Address");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerKm",
                table: "Routes",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "CurrentLatitude",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CurrentLongitude",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EndLatitude",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "EndLongitude",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EveningStartTime",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MorningStartTime",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "StartLatitude",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "StartLongitude",
                table: "Routes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "RouteId",
                table: "Passangers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Passangers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Passangers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "RouteWaypoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    StopOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteWaypoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteWaypoint_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passangers_RouteId",
                table: "Passangers",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_CompanyID",
                table: "Managers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDrivers_CompanyID",
                table: "CompanyDrivers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDrivers_DriverID",
                table: "CompanyDrivers",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDrivers_PaymentID",
                table: "CompanyDrivers",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDrivers_RouteID",
                table: "CompanyDrivers",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_RouteId",
                table: "RouteWaypoint",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDrivers_Companies_CompanyID",
                table: "CompanyDrivers",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDrivers_Drivers_DriverID",
                table: "CompanyDrivers",
                column: "DriverID",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDrivers_Payment_PaymentID",
                table: "CompanyDrivers",
                column: "PaymentID",
                principalTable: "Payment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyDrivers_Routes_RouteID",
                table: "CompanyDrivers",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Companies_CompanyID",
                table: "Managers",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passangers_Routes_RouteId",
                table: "Passangers",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDrivers_Companies_CompanyID",
                table: "CompanyDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDrivers_Drivers_DriverID",
                table: "CompanyDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDrivers_Payment_PaymentID",
                table: "CompanyDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyDrivers_Routes_RouteID",
                table: "CompanyDrivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Companies_CompanyID",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Passangers_Routes_RouteId",
                table: "Passangers");

            migrationBuilder.DropTable(
                name: "RouteWaypoint");

            migrationBuilder.DropIndex(
                name: "IX_Passangers_RouteId",
                table: "Passangers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_CompanyID",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyDrivers_CompanyID",
                table: "CompanyDrivers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyDrivers_DriverID",
                table: "CompanyDrivers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyDrivers_PaymentID",
                table: "CompanyDrivers");

            migrationBuilder.DropIndex(
                name: "IX_CompanyDrivers_RouteID",
                table: "CompanyDrivers");

            migrationBuilder.DropColumn(
                name: "CurrentLatitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "CurrentLongitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EndLatitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EndLongitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "EveningStartTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "MorningStartTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartLatitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "StartLongitude",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Passangers");

            migrationBuilder.RenameColumn(
                name: "PricePerKm",
                table: "Routes",
                newName: "PricePerKM");

            migrationBuilder.RenameColumn(
                name: "RouteId",
                table: "Passangers",
                newName: "RouteID");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Passangers",
                newName: "Coordinats");

            migrationBuilder.RenameColumn(
                name: "IdentityCardPhotoUrl",
                table: "Drivers",
                newName: "IdentityCardPhoto");

            migrationBuilder.RenameColumn(
                name: "DriverCardPhotoUrl",
                table: "Drivers",
                newName: "DriverCardPhoto");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Drivers",
                newName: "Adress");

            migrationBuilder.AlterColumn<string>(
                name: "PricePerKM",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "CurrentLocation",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndCoordinats",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EveningStartHour",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MorningStartHour",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartCoordinats",
                table: "Routes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "RouteID",
                table: "Passangers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Passangers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
