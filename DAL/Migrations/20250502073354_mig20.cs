using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PickupLatitude",
                table: "Passangers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PickupLongitude",
                table: "Passangers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WalkingDistanceInMeters",
                table: "Passangers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickupLatitude",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "PickupLongitude",
                table: "Passangers");

            migrationBuilder.DropColumn(
                name: "WalkingDistanceInMeters",
                table: "Passangers");
        }
    }
}
