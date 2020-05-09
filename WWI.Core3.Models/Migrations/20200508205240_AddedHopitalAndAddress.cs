using Microsoft.EntityFrameworkCore.Migrations;

namespace WWI.Core3.Models.Migrations
{
    public partial class AddedHopitalAndAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HospitalID",
                table: "Doctors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    District = table.Column<string>(maxLength: 50, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hospitals_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_HospitalID",
                table: "Doctors",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_AddressID",
                table: "Hospitals",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Hospitals_HospitalID",
                table: "Doctors",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Hospitals_HospitalID",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_HospitalID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "Doctors");
        }
    }
}
