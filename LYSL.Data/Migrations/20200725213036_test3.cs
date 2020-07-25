using Microsoft.EntityFrameworkCore.Migrations;

namespace LYSL.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Location_LocationId",
                table: "Pet");

            migrationBuilder.DropIndex(
                name: "IX_Pet_LocationId",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Pet");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Location",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Location_PetId",
                table: "Location",
                column: "PetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Pet_PetId",
                table: "Location",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Pet_PetId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_PetId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Location");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Pet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pet_LocationId",
                table: "Pet",
                column: "LocationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Location_LocationId",
                table: "Pet",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
