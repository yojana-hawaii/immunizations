using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NameWithoutAllLowercase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CdcCvxCpts",
                columns: table => new
                {
                    CdcCvxCptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CptCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CptDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    VaccineName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LateUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxCpts", x => x.CdcCvxCptId);
                    table.UniqueConstraint("IX_cvx_cpt", x => new { x.CdcCvxCode, x.CptCode });
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxes",
                columns: table => new
                {
                    CdcCvxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FullVaccineName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VaccineStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NonVaccine = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxes", x => x.CdcCvxId);
                    table.UniqueConstraint("IX_cvx", x => x.CdcCvxCode);
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxManufacturers",
                columns: table => new
                {
                    CdcCvxManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdcProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MvxStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ProductNameStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastUpdatedDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxManufacturers", x => x.CdcCvxManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxVaccineGroups",
                columns: table => new
                {
                    CdcCvxVaccineGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    VaccineStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VaccineGroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VaccineGroupCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxVaccineGroups", x => x.CdcCvxVaccineGroupId);
                });

            migrationBuilder.CreateTable(
                name: "CdcCvxVises",
                columns: table => new
                {
                    CdcVisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CvxVaccineDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VisFullyEncodedTextString = table.Column<int>(type: "int", nullable: false),
                    VisDocumentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VisEditionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VisEditionStatus = table.Column<bool>(type: "bit", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcCvxVises", x => x.CdcVisId);
                });

            migrationBuilder.CreateTable(
                name: "CdcLookupNdcs",
                columns: table => new
                {
                    CdcLookupNdc10Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleNdc11 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SaleNdc10 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UseNdc11 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UseNdc10 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SaleProprietaryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SaleLabeler = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SalePackageForm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Route = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SaleStatDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SaleEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    SaleGtin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SaleLastUpdate = table.Column<DateOnly>(type: "date", nullable: false),
                    VaccineSeason = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseUnitPackerForm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UseStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UseEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    UseGtin = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserLastUpdate = table.Column<DateOnly>(type: "date", nullable: false),
                    CdcCvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CvxShortDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CvxLongDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CvxStatus = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CvxEddectiveDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CvxRetiredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    MvxCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MvxStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CptCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    CptShortDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CptLongDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CptStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcLookupNdcs", x => x.CdcLookupNdc10Id);
                });

            migrationBuilder.CreateTable(
                name: "CdcLoopupBarcodes",
                columns: table => new
                {
                    CdcBarcodeLookupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisDocumentTypeDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EditionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VisFullyEncodedString = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VisGdtiCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EditionStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LateUpdateDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcLoopupBarcodes", x => x.CdcBarcodeLookupId);
                    table.UniqueConstraint("IX_encodedString", x => x.VisFullyEncodedString);
                });

            migrationBuilder.CreateTable(
                name: "CdcManufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    MvxCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ManufacturerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufacturerNotes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ManufacturerStatus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LastUpdateDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CdcManufacturers", x => x.ManufacturerId);
                    table.UniqueConstraint("AK_CdcManufacturers_MvxCode", x => x.MvxCode);
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
                name: "IX_ndc11_ndc10_cvx_mvx",
                table: "CdcLookupNdcs",
                columns: new[] { "SaleNdc11", "SaleNdc10", "UseNdc11", "UseNdc10", "CdcCvxCode", "MvxCode" },
                unique: true,
                filter: "[SaleNdc10] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CdcCvxCpts");

            migrationBuilder.DropTable(
                name: "CdcCvxes");

            migrationBuilder.DropTable(
                name: "CdcCvxManufacturers");

            migrationBuilder.DropTable(
                name: "CdcCvxVaccineGroups");

            migrationBuilder.DropTable(
                name: "CdcCvxVises");

            migrationBuilder.DropTable(
                name: "CdcLookupNdcs");

            migrationBuilder.DropTable(
                name: "CdcLoopupBarcodes");

            migrationBuilder.DropTable(
                name: "CdcManufacturers");
        }
    }
}
