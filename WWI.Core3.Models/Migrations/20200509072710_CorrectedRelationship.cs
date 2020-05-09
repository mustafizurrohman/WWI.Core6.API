using Microsoft.EntityFrameworkCore.Migrations;

namespace WWI.Core3.Models.Migrations
{
    public partial class CorrectedRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityID2",
                table: "Doctors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialityID1",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityID2",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityID1",
                table: "Doctors",
                column: "SpecialityID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID1",
                table: "Doctors",
                column: "SpecialityID1",
                principalTable: "Specialities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
