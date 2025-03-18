using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.TenantMigration
{
    /// <inheritdoc />
    public partial class TenantEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "VaccineBrands",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineBrandCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    VaccineBrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VaccineBrandManufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SaleNdc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UseNdc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineGroups",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineGroupCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    VaccineGroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VaccineGroupDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VisDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineLocations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ComputedSubLocationForUniqueness = table.Column<string>(type: "nvarchar(450)", nullable: false, computedColumnSql: "isnull(SubLocation, 'NULL-MARKER')"),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineLotNumbers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VaccineExpirationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineLotNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccinePrograms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineProgramName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VaccineProgramDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinePrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineSources",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccineSourceName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VaccineSourceDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCveCodes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CvxCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ShortDescripton = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullVaccineName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VaccineStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NonVaccine = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VaccineGroupId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCveCodes", x => x.Id);
                    table.UniqueConstraint("AK_VaccineCveCodes_CvxCode", x => x.CvxCode);
                    table.ForeignKey(
                        name: "FK_VaccineCveCodes_VaccineGroups_VaccineGroupId",
                        column: x => x.VaccineGroupId,
                        principalSchema: "dbo",
                        principalTable: "VaccineGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCveCodes_VaccineGroupId",
                schema: "dbo",
                table: "VaccineCveCodes",
                column: "VaccineGroupId");

            migrationBuilder.CreateIndex(
                name: "ix_location",
                schema: "dbo",
                table: "VaccineLocations",
                columns: new[] { "LocationName", "ComputedSubLocationForUniqueness" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaccine_program",
                schema: "dbo",
                table: "VaccinePrograms",
                column: "VaccineProgramName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaccine_source",
                schema: "dbo",
                table: "VaccineSources",
                column: "VaccineSourceName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccineBrands",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccineCveCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccineLocations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccineLotNumbers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccinePrograms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccineSources",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VaccineGroups",
                schema: "dbo");
        }
    }
}
