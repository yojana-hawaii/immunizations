using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.YojanaMigration
{
    /// <inheritdoc />
    public partial class YojanaEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CdcCvxCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullVaccineName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VaccineStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NonVaccine = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxCodes", x => x.Id);
                    table.UniqueConstraint("IX_cvx", x => x.CvxCode);
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxCpts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CptCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CptDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CvxDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CptCodeId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxCpts", x => x.Id);
                    table.UniqueConstraint("IX_cvx_cpt", x => new { x.CdcCvxCode, x.CptCode });
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdcProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MvxStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ProductNameStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxVaccineGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    VaccineStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VaccineGroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VaccineGroupCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxVaccineGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxVises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CvxVaccineDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VisFullyEncodedTextString = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    VisDocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VisEditionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VisEditionStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxVises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CdcLookupBarcodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisDocumentTypeDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EditionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VisFullyEncodedString = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VisGdtiCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EditionStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LateUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcLookupBarcodes", x => x.Id);
                    table.UniqueConstraint("IX_encodedString", x => new { x.VisFullyEncodedString, x.EditionStatus });
                });

            migrationBuilder.CreateTable(
                name: "CdcLookupNdcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleNdc11 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SaleNdc10 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UseNdc11 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UseNdc10 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SaleProprietaryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SaleLabeler = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalePackageForm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Route = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SaleStatDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SaleEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SaleGtin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleLastUpdated = table.Column<DateOnly>(type: "date", nullable: false),
                    VaccineSeason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseUnitPackerForm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UseStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UseEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UseGtin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserLastUpdated = table.Column<DateOnly>(type: "date", nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CvxShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CvxLongDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CvxStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CvxEffectiveDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CvxRetiredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MvxCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MvxStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CptCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CptShortDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CptLongDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CptStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcLookupNdcs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CdcManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufacturerNotes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ManufacturerStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcManufacturers", x => x.Id);
                    table.UniqueConstraint("AK_CdcManufacturers_MvxCode", x => x.MvxCode);
                });

            migrationBuilder.CreateTable(
                name: "VaccineGroup",
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
                    table.PrimaryKey("PK_VaccineGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineLocation",
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
                    table.PrimaryKey("PK_VaccineLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineProgram",
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
                    table.PrimaryKey("PK_VaccineProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineSource",
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
                    table.PrimaryKey("PK_VaccineSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCvxCode",
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
                    table.PrimaryKey("PK_VaccineCvxCode", x => x.Id);
                    table.UniqueConstraint("AK_VaccineCvxCode_CvxCode", x => x.CvxCode);
                    table.ForeignKey(
                        name: "FK_VaccineCvxCode_VaccineGroup_VaccineGroupId",
                        column: x => x.VaccineGroupId,
                        principalTable: "VaccineGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_name_mvx_cvx",
                table: "CdcCvxManufacturers",
                columns: new[] { "CdcProductName", "MvxCode", "CdcCvxCode" },
                unique: true,
                filter: "[MvxCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cvx_groupcvx",
                table: "CdcCvxVaccineGroups",
                columns: new[] { "CdcCvxCode", "VaccineGroupCvxCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cvx_visname_visdate",
                table: "CdcCvxVises",
                columns: new[] { "CdcCvxCode", "VisDocumentName", "VisEditionDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cpt",
                table: "CdcLookupNdcs",
                column: "CptCode");

            migrationBuilder.CreateIndex(
                name: "IX_cvx",
                table: "CdcLookupNdcs",
                column: "CdcCvxCode");

            migrationBuilder.CreateIndex(
                name: "IX_mvx",
                table: "CdcLookupNdcs",
                column: "MvxCode");

            migrationBuilder.CreateIndex(
                name: "IX_ndc11_ndc10_cvx_mvx_cpt",
                table: "CdcLookupNdcs",
                columns: new[] { "SaleNdc11", "SaleNdc10", "UseNdc11", "UseNdc10", "CdcCvxCode", "MvxCode", "CptCode" },
                unique: true,
                filter: "[SaleNdc10] IS NOT NULL AND [CptCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_sale_ndc10",
                table: "CdcLookupNdcs",
                column: "SaleNdc10");

            migrationBuilder.CreateIndex(
                name: "IX_sale_ndc11",
                table: "CdcLookupNdcs",
                column: "SaleNdc11");

            migrationBuilder.CreateIndex(
                name: "IX_use_ndc10",
                table: "CdcLookupNdcs",
                column: "UseNdc10");

            migrationBuilder.CreateIndex(
                name: "IX_use_ndc11",
                table: "CdcLookupNdcs",
                column: "UseNdc11");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCvxCode_VaccineGroupId",
                table: "VaccineCvxCode",
                column: "VaccineGroupId");

            migrationBuilder.CreateIndex(
                name: "ix_location",
                table: "VaccineLocation",
                columns: new[] { "LocationName", "ComputedSubLocationForUniqueness" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaccine_program",
                table: "VaccineProgram",
                column: "VaccineProgramName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vaccine_source",
                table: "VaccineSource",
                column: "VaccineSourceName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CdcCvxCodes");

            migrationBuilder.DropTable(
                name: "CdcCvxCpts");

            migrationBuilder.DropTable(
                name: "CdcCvxManufacturers");

            migrationBuilder.DropTable(
                name: "CdcCvxVaccineGroups");

            migrationBuilder.DropTable(
                name: "CdcCvxVises");

            migrationBuilder.DropTable(
                name: "CdcLookupBarcodes");

            migrationBuilder.DropTable(
                name: "CdcLookupNdcs");

            migrationBuilder.DropTable(
                name: "CdcManufacturers");

            migrationBuilder.DropTable(
                name: "VaccineCvxCode");

            migrationBuilder.DropTable(
                name: "VaccineLocation");

            migrationBuilder.DropTable(
                name: "VaccineProgram");

            migrationBuilder.DropTable(
                name: "VaccineSource");

            migrationBuilder.DropTable(
                name: "VaccineGroup");
        }
    }
}
