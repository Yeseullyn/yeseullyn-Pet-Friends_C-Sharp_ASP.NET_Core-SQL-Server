using Microsoft.EntityFrameworkCore.Migrations;

namespace LYSL.Data.Migrations
{
    public partial class EditpropertyinPetclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Location",
                newName: "Id");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Pets",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Location",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
