﻿using System;
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
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CdcCvxCodes",
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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
                schema: "dbo",
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

            migrationBuilder.CreateIndex(
                name: "IX_name_mvx_cvx",
                schema: "dbo",
                table: "CdcCvxManufacturers",
                columns: new[] { "CdcProductName", "MvxCode", "CdcCvxCode" },
                unique: true,
                filter: "[MvxCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cvx_groupcvx",
                schema: "dbo",
                table: "CdcCvxVaccineGroups",
                columns: new[] { "CdcCvxCode", "VaccineGroupCvxCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cvx_visname_visdate",
                schema: "dbo",
                table: "CdcCvxVises",
                columns: new[] { "CdcCvxCode", "VisDocumentName", "VisEditionDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cpt",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "CptCode");

            migrationBuilder.CreateIndex(
                name: "IX_cvx",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "CdcCvxCode");

            migrationBuilder.CreateIndex(
                name: "IX_mvx",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "MvxCode");

            migrationBuilder.CreateIndex(
                name: "IX_ndc11_ndc10_cvx_mvx_cpt",
                schema: "dbo",
                table: "CdcLookupNdcs",
                columns: new[] { "SaleNdc11", "SaleNdc10", "UseNdc11", "UseNdc10", "CdcCvxCode", "MvxCode", "CptCode" },
                unique: true,
                filter: "[SaleNdc10] IS NOT NULL AND [CptCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_sale_ndc10",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "SaleNdc10");

            migrationBuilder.CreateIndex(
                name: "IX_sale_ndc11",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "SaleNdc11");

            migrationBuilder.CreateIndex(
                name: "IX_use_ndc10",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "UseNdc10");

            migrationBuilder.CreateIndex(
                name: "IX_use_ndc11",
                schema: "dbo",
                table: "CdcLookupNdcs",
                column: "UseNdc11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CdcCvxCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcCvxCpts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcCvxManufacturers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcCvxVaccineGroups",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcCvxVises",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcLookupBarcodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcLookupNdcs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CdcManufacturers",
                schema: "dbo");
        }
    }
}
