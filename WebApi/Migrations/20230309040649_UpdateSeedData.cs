using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_Cityid",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_Cityid",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Cityid",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "CitiesId",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CitiesId",
                table: "Cars",
                column: "CitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_CitiesId",
                table: "Cars",
                column: "CitiesId",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cities_CitiesId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CitiesId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "CitiesId",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Cityid",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Cityid",
                table: "Cars",
                column: "Cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cities_Cityid",
                table: "Cars",
                column: "Cityid",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
