using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IAuditableExtensionToAllCdcTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcManufacturers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcManufacturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcManufacturers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcManufacturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcLoopupBarcodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcLoopupBarcodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcLoopupBarcodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcLoopupBarcodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcLookupNdcs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcLookupNdcs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcLookupNdcs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcLookupNdcs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcCvxVises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcCvxVises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcCvxVises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcCvxVises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcCvxVaccineGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcCvxVaccineGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcCvxVaccineGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcCvxVaccineGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcCvxManufacturers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcCvxManufacturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcCvxManufacturers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcCvxManufacturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcCvxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcCvxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcCvxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcCvxes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CdcCvxCpts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CdcCvxCpts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CdcCvxCpts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CdcCvxCpts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcManufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcManufacturers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcManufacturers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcManufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcLoopupBarcodes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcLoopupBarcodes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcLoopupBarcodes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcLoopupBarcodes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcLookupNdcs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcLookupNdcs");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcLookupNdcs");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcLookupNdcs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcCvxVises");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcCvxVises");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcCvxVises");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcCvxVises");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcCvxVaccineGroups");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcCvxVaccineGroups");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcCvxVaccineGroups");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcCvxVaccineGroups");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcCvxManufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcCvxManufacturers");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcCvxManufacturers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcCvxManufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcCvxes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcCvxes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcCvxes");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcCvxes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CdcCvxCpts");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CdcCvxCpts");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CdcCvxCpts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CdcCvxCpts");
        }
    }
}
