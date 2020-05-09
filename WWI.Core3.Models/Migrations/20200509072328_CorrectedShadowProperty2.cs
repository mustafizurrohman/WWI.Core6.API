using Microsoft.EntityFrameworkCore.Migrations;

namespace WWI.Core3.Models.Migrations
{
    public partial class CorrectedShadowProperty2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Allergy and Immunology");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Allerfy and Immunology");
        }
    }
}
