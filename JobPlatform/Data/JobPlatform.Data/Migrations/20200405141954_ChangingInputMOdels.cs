using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPlatform.Data.Migrations
{
    public partial class ChangingInputMOdels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UploadedFile = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTables", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileTables_IsDeleted",
                table: "FileTables",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileTables");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");
        }
    }
}
