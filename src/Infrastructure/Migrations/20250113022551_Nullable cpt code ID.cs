using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NullablecptcodeID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VaccineName",
                table: "CdcCvxCpts",
                newName: "CvxDescription");

            migrationBuilder.AddColumn<int>(
                name: "CptCodeId",
                table: "CdcCvxCpts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CptCodeId",
                table: "CdcCvxCpts");

            migrationBuilder.RenameColumn(
                name: "CvxDescription",
                table: "CdcCvxCpts",
                newName: "VaccineName");
        }
    }
}
