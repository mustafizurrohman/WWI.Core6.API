using Microsoft.EntityFrameworkCore.Migrations;

namespace WWI.Core3.Models.Migrations
{
    public partial class AddedSpecilitySeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Hospitals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityID1",
                table: "Doctors",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 4, "Allerfy and Immunology" },
                    { 5, "Anesthesiology" },
                    { 6, "Diagonistic Radiology" },
                    { 7, "Emergency Medicine" },
                    { 8, "Family Medicine" },
                    { 9, "Internal Medicine" },
                    { 10, "Medical Genetics" },
                    { 11, "Neurology" },
                    { 12, "Neuclear Medicine" },
                    { 13, "Obstetrics and Gynecology" },
                    { 14, "Opthalmology" },
                    { 15, "Physical Medicine & Rehabilitation" },
                    { 16, "Psychiatry" },
                    { 17, "Radiation Oncology" },
                    { 18, "Surgery" },
                    { 19, "Urology" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityID1",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_SpecialityID1",
                table: "Doctors");

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "SpecialityID1",
                table: "Doctors");
        }
    }
}
