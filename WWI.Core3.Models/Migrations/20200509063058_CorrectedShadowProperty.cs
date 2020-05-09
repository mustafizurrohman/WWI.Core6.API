using Microsoft.EntityFrameworkCore.Migrations;

namespace WWI.Core3.Models.Migrations
{
    public partial class CorrectedShadowProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialityID",
                table: "Doctors",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityID2",
                table: "Doctors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID",
                table: "Doctors",
                column: "SpecialityID",
                principalTable: "Specialities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "SpecialityID2",
                table: "Doctors");

            migrationBuilder.AlterColumn<int>(
                name: "SpecialityID",
                table: "Doctors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID",
                table: "Doctors",
                column: "SpecialityID",
                principalTable: "Specialities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
