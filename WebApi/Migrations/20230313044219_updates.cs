using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {   
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "Photos",
                newName: "publicId");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Photos",
                newName: "imageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "publicId",
                table: "Photos",
                newName: "PublicId");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "Photos",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
