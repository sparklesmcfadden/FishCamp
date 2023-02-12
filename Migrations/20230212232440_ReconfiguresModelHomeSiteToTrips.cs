using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FishCamp.Migrations
{
    /// <inheritdoc />
    public partial class ReconfiguresModelHomeSiteToTrips : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_HomeSites_HomeSiteId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "HomeSiteComments");

            migrationBuilder.DropTable(
                name: "HomeSiteLocations");

            migrationBuilder.DropTable(
                name: "HomeSitePhotos");

            migrationBuilder.DropTable(
                name: "HomeSiteUsers");

            migrationBuilder.DropTable(
                name: "LocationUsers");

            migrationBuilder.DropTable(
                name: "HomeSites");

            migrationBuilder.DropIndex(
                name: "IX_Locations_HomeSiteId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "HomeSiteId",
                table: "Locations");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LocationVisits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Locations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Locations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripName = table.Column<string>(type: "text", nullable: false),
                    TripDescription = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "LocationTrips",
                columns: table => new
                {
                    LocationTripId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    TripId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTrips", x => x.LocationTripId);
                    table.ForeignKey(
                        name: "FK_LocationTrips_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationTrips_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripComments",
                columns: table => new
                {
                    TripCommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripId = table.Column<int>(type: "integer", nullable: false),
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripComments", x => x.TripCommentId);
                    table.ForeignKey(
                        name: "FK_TripComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripComments_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripUsers",
                columns: table => new
                {
                    TripUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripUsers", x => x.TripUserId);
                    table.ForeignKey(
                        name: "FK_TripUsers_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "TripId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TripUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreatedById",
                table: "Locations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTrips_LocationId",
                table: "LocationTrips",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationTrips_TripId",
                table: "LocationTrips",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripComments_CommentId",
                table: "TripComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_TripComments_TripId",
                table: "TripComments",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripUsers_TripId",
                table: "TripUsers",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripUsers_UserId",
                table: "TripUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_User_CreatedById",
                table: "Locations",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_User_CreatedById",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "LocationTrips");

            migrationBuilder.DropTable(
                name: "TripComments");

            migrationBuilder.DropTable(
                name: "TripUsers");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CreatedById",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LocationVisits");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "HomeSiteId",
                table: "Locations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeSites",
                columns: table => new
                {
                    HomeSiteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HomeSiteDescription = table.Column<string>(type: "text", nullable: false),
                    HomeSiteName = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSites", x => x.HomeSiteId);
                });

            migrationBuilder.CreateTable(
                name: "LocationUsers",
                columns: table => new
                {
                    LocationUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationUsers", x => x.LocationUserId);
                    table.ForeignKey(
                        name: "FK_LocationUsers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeSiteComments",
                columns: table => new
                {
                    HomeSiteCommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<int>(type: "integer", nullable: false),
                    HomeSiteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSiteComments", x => x.HomeSiteCommentId);
                    table.ForeignKey(
                        name: "FK_HomeSiteComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSiteComments_HomeSites_HomeSiteId",
                        column: x => x.HomeSiteId,
                        principalTable: "HomeSites",
                        principalColumn: "HomeSiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeSiteLocations",
                columns: table => new
                {
                    HomeSiteLocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeSiteId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSiteLocations", x => x.HomeSiteLocationId);
                    table.ForeignKey(
                        name: "FK_HomeSiteLocations_HomeSites_HomeSiteId",
                        column: x => x.HomeSiteId,
                        principalTable: "HomeSites",
                        principalColumn: "HomeSiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSiteLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeSitePhotos",
                columns: table => new
                {
                    HomeSitePhotoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeSiteId = table.Column<int>(type: "integer", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSitePhotos", x => x.HomeSitePhotoId);
                    table.ForeignKey(
                        name: "FK_HomeSitePhotos_HomeSites_HomeSiteId",
                        column: x => x.HomeSiteId,
                        principalTable: "HomeSites",
                        principalColumn: "HomeSiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSitePhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HomeSiteUsers",
                columns: table => new
                {
                    HomeSiteUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeSiteId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSiteUsers", x => x.HomeSiteUserId);
                    table.ForeignKey(
                        name: "FK_HomeSiteUsers_HomeSites_HomeSiteId",
                        column: x => x.HomeSiteId,
                        principalTable: "HomeSites",
                        principalColumn: "HomeSiteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HomeSiteUsers_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HomeSiteId",
                table: "Locations",
                column: "HomeSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSiteComments_CommentId",
                table: "HomeSiteComments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSiteComments_HomeSiteId",
                table: "HomeSiteComments",
                column: "HomeSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSiteLocations_HomeSiteId",
                table: "HomeSiteLocations",
                column: "HomeSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSiteLocations_LocationId",
                table: "HomeSiteLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSitePhotos_HomeSiteId",
                table: "HomeSitePhotos",
                column: "HomeSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSitePhotos_PhotoId",
                table: "HomeSitePhotos",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSiteUsers_HomeSiteId",
                table: "HomeSiteUsers",
                column: "HomeSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_HomeSiteUsers_UserId",
                table: "HomeSiteUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationUsers_LocationId",
                table: "LocationUsers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationUsers_UserId",
                table: "LocationUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_HomeSites_HomeSiteId",
                table: "Locations",
                column: "HomeSiteId",
                principalTable: "HomeSites",
                principalColumn: "HomeSiteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
