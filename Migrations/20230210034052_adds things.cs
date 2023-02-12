using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishCamp.Migrations
{
    /// <inheritdoc />
    public partial class addsthings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisit_Locations_LocationId",
                table: "LocationVisit");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitComment_Comments_CommentId",
                table: "LocationVisitComment");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitComment_LocationVisit_LocationVisitId",
                table: "LocationVisitComment");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitPhoto_LocationVisit_LocationVisitId",
                table: "LocationVisitPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitPhoto_Photos_PhotoId",
                table: "LocationVisitPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitUser_LocationVisit_LocationVisitId",
                table: "LocationVisitUser");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitUser_User_UserId",
                table: "LocationVisitUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisitUser",
                table: "LocationVisitUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisitPhoto",
                table: "LocationVisitPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisitComment",
                table: "LocationVisitComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisit",
                table: "LocationVisit");

            migrationBuilder.RenameTable(
                name: "LocationVisitUser",
                newName: "LocationVisitUsers");

            migrationBuilder.RenameTable(
                name: "LocationVisitPhoto",
                newName: "LocationVisitPhotos");

            migrationBuilder.RenameTable(
                name: "LocationVisitComment",
                newName: "LocationVisitComments");

            migrationBuilder.RenameTable(
                name: "LocationVisit",
                newName: "LocationVisits");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitUser_UserId",
                table: "LocationVisitUsers",
                newName: "IX_LocationVisitUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitUser_LocationVisitId",
                table: "LocationVisitUsers",
                newName: "IX_LocationVisitUsers_LocationVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitPhoto_PhotoId",
                table: "LocationVisitPhotos",
                newName: "IX_LocationVisitPhotos_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitPhoto_LocationVisitId",
                table: "LocationVisitPhotos",
                newName: "IX_LocationVisitPhotos_LocationVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitComment_LocationVisitId",
                table: "LocationVisitComments",
                newName: "IX_LocationVisitComments_LocationVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitComment_CommentId",
                table: "LocationVisitComments",
                newName: "IX_LocationVisitComments_CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisit_LocationId",
                table: "LocationVisits",
                newName: "IX_LocationVisits_LocationId");

            migrationBuilder.AddColumn<int>(
                name: "HomeSiteId",
                table: "Locations",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LocationVisitUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationVisits",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisitUsers",
                table: "LocationVisitUsers",
                column: "LocationVisitUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisitPhotos",
                table: "LocationVisitPhotos",
                column: "LocationVisitPhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisitComments",
                table: "LocationVisitComments",
                column: "LocationVisitCommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisits",
                table: "LocationVisits",
                column: "LocationVisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_HomeSiteId",
                table: "Locations",
                column: "HomeSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_HomeSites_HomeSiteId",
                table: "Locations",
                column: "HomeSiteId",
                principalTable: "HomeSites",
                principalColumn: "HomeSiteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitComments_Comments_CommentId",
                table: "LocationVisitComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitComments_LocationVisits_LocationVisitId",
                table: "LocationVisitComments",
                column: "LocationVisitId",
                principalTable: "LocationVisits",
                principalColumn: "LocationVisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitPhotos_LocationVisits_LocationVisitId",
                table: "LocationVisitPhotos",
                column: "LocationVisitId",
                principalTable: "LocationVisits",
                principalColumn: "LocationVisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitPhotos_Photos_PhotoId",
                table: "LocationVisitPhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisits_Locations_LocationId",
                table: "LocationVisits",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitUsers_LocationVisits_LocationVisitId",
                table: "LocationVisitUsers",
                column: "LocationVisitId",
                principalTable: "LocationVisits",
                principalColumn: "LocationVisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitUsers_User_UserId",
                table: "LocationVisitUsers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_HomeSites_HomeSiteId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitComments_Comments_CommentId",
                table: "LocationVisitComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitComments_LocationVisits_LocationVisitId",
                table: "LocationVisitComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitPhotos_LocationVisits_LocationVisitId",
                table: "LocationVisitPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitPhotos_Photos_PhotoId",
                table: "LocationVisitPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisits_Locations_LocationId",
                table: "LocationVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitUsers_LocationVisits_LocationVisitId",
                table: "LocationVisitUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationVisitUsers_User_UserId",
                table: "LocationVisitUsers");

            migrationBuilder.DropIndex(
                name: "IX_Locations_HomeSiteId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisitUsers",
                table: "LocationVisitUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisits",
                table: "LocationVisits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisitPhotos",
                table: "LocationVisitPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationVisitComments",
                table: "LocationVisitComments");

            migrationBuilder.DropColumn(
                name: "HomeSiteId",
                table: "Locations");

            migrationBuilder.RenameTable(
                name: "LocationVisitUsers",
                newName: "LocationVisitUser");

            migrationBuilder.RenameTable(
                name: "LocationVisits",
                newName: "LocationVisit");

            migrationBuilder.RenameTable(
                name: "LocationVisitPhotos",
                newName: "LocationVisitPhoto");

            migrationBuilder.RenameTable(
                name: "LocationVisitComments",
                newName: "LocationVisitComment");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitUsers_UserId",
                table: "LocationVisitUser",
                newName: "IX_LocationVisitUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitUsers_LocationVisitId",
                table: "LocationVisitUser",
                newName: "IX_LocationVisitUser_LocationVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisits_LocationId",
                table: "LocationVisit",
                newName: "IX_LocationVisit_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitPhotos_PhotoId",
                table: "LocationVisitPhoto",
                newName: "IX_LocationVisitPhoto_PhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitPhotos_LocationVisitId",
                table: "LocationVisitPhoto",
                newName: "IX_LocationVisitPhoto_LocationVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitComments_LocationVisitId",
                table: "LocationVisitComment",
                newName: "IX_LocationVisitComment_LocationVisitId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationVisitComments_CommentId",
                table: "LocationVisitComment",
                newName: "IX_LocationVisitComment_CommentId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LocationVisitUser",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationVisit",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisitUser",
                table: "LocationVisitUser",
                column: "LocationVisitUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisit",
                table: "LocationVisit",
                column: "LocationVisitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisitPhoto",
                table: "LocationVisitPhoto",
                column: "LocationVisitPhotoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationVisitComment",
                table: "LocationVisitComment",
                column: "LocationVisitCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisit_Locations_LocationId",
                table: "LocationVisit",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitComment_Comments_CommentId",
                table: "LocationVisitComment",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "CommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitComment_LocationVisit_LocationVisitId",
                table: "LocationVisitComment",
                column: "LocationVisitId",
                principalTable: "LocationVisit",
                principalColumn: "LocationVisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitPhoto_LocationVisit_LocationVisitId",
                table: "LocationVisitPhoto",
                column: "LocationVisitId",
                principalTable: "LocationVisit",
                principalColumn: "LocationVisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitPhoto_Photos_PhotoId",
                table: "LocationVisitPhoto",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitUser_LocationVisit_LocationVisitId",
                table: "LocationVisitUser",
                column: "LocationVisitId",
                principalTable: "LocationVisit",
                principalColumn: "LocationVisitId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationVisitUser_User_UserId",
                table: "LocationVisitUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
