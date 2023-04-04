using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class UpdateUserForPasswordEncryption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("password","Users");
            migrationBuilder.AddColumn<byte[]>(
                name: "password",
                table: "Users",
                nullable: false,
                defaultValue: "Aarif@123"
                // oldClrType: typeof(string),
                // oldType: "nvarchar(max)",
                // oldNullable: true
                );

            migrationBuilder.AddColumn<byte[]>(
                name: "passwordKey",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "passwordKey",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
