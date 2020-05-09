using Microsoft.EntityFrameworkCore.Migrations;

namespace WWI.Core3.Models.Migrations
{
    public partial class HospitalDoctorManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Hospitals_HospitalID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HospitalID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Doctors");

            migrationBuilder.CreateTable(
                name: "HospitalDoctors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<int>(nullable: false),
                    HospitalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalDoctors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HospitalDoctors_Hospitals_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Hospitals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HospitalDoctors_Doctors_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Doctors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctors_DoctorID",
                table: "HospitalDoctors",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalDoctors_HospitalID",
                table: "HospitalDoctors",
                column: "HospitalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HospitalDoctors");

            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalID",
                table: "Doctors",
                column: "HospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Hospitals_HospitalID",
                table: "Doctors",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
