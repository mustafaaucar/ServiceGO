using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
