using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishCamp.Migrations
{
    /// <inheritdoc />
    public partial class coordinateslatlong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordinates",
                table: "Locations",
                newName: "LocationName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "HomeSites",
                newName: "HomeSiteName");

            migrationBuilder.RenameColumn(
                name: "Coordinates",
                table: "HomeSites",
                newName: "HomeSiteDescription");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Locations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LocationDescription",
                table: "Locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Locations",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "HomeSites",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "HomeSites",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationDescription",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "HomeSites");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "HomeSites");

            migrationBuilder.RenameColumn(
                name: "LocationName",
                table: "Locations",
                newName: "Coordinates");

            migrationBuilder.RenameColumn(
                name: "HomeSiteName",
                table: "HomeSites",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "HomeSiteDescription",
                table: "HomeSites",
                newName: "Coordinates");
        }
    }
}
