﻿// <auto-generated />
using System;
using DbMigration.dbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbMigration.Migrations
{
    [DbContext(typeof(TestCdcDbContext))]
    partial class TestCdcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.CDC.CdcCvx", b =>
                {
                    b.Property<int>("CdcCvxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcCvxId"));

                    b.Property<string>("CdcCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("FullVaccineName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("LastUpdatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VaccineStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CdcCvxId");

                    b.HasAlternateKey("CdcCvxCode")
                        .HasName("IX_cvx");

                    b.ToTable("CdcCvxes");
                });

            modelBuilder.Entity("Domain.CDC.CdcCvxCpt", b =>
                {
                    b.Property<int>("CdcCvxCptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcCvxCptId"));

                    b.Property<string>("CdcCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Comments")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CptCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CptDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("LateUpdatedDate")
                        .HasColumnType("date");

                    b.Property<string>("VaccineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CdcCvxCptId");

                    b.HasAlternateKey("CdcCvxCode", "CptCode")
                        .HasName("IX_cvx_cpt");

                    b.ToTable("CdcCvxCpts");
                });

            modelBuilder.Entity("Domain.CDC.CdcCvxManufacturer", b =>
                {
                    b.Property<int>("CdcCvxManufacturerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcCvxManufacturerId"));

                    b.Property<string>("CdcCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CdcProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("LastUpdatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Manufacturer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MvxCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("MvxStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ProductNameStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CdcCvxManufacturerId");

                    b.HasIndex("CdcProductName", "MvxCode", "CdcCvxCode")
                        .IsUnique()
                        .HasDatabaseName("IX_name_mvx_cvx")
                        .HasFilter("[MvxCode] IS NOT NULL");

                    b.ToTable("CdcCvxManufacturers");
                });

            modelBuilder.Entity("Domain.CDC.CdcCvxVaccineGroup", b =>
                {
                    b.Property<int>("CdcCvxVaccineGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcCvxVaccineGroupId"));

                    b.Property<string>("CdcCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VaccineGroupCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("VaccineGroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VaccineStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CdcCvxVaccineGroupId");

                    b.HasIndex("CdcCvxCode", "VaccineGroupCvxCode")
                        .IsUnique()
                        .HasDatabaseName("IX_cvx_groupcvx");

                    b.ToTable("CdcCvxVaccineGroups");
                });

            modelBuilder.Entity("Domain.CDC.CdcCvxVis", b =>
                {
                    b.Property<int>("CdcVisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcVisId"));

                    b.Property<string>("CdcCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CvxVaccineDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VisDocumentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("VisEditionDate")
                        .HasColumnType("date");

                    b.Property<bool>("VisEditionStatus")
                        .HasMaxLength(15)
                        .HasColumnType("bit");

                    b.Property<int>("VisFullyEncodedTextString")
                        .HasColumnType("int");

                    b.HasKey("CdcVisId");

                    b.HasIndex("CdcCvxCode", "VisDocumentName", "VisEditionDate")
                        .IsUnique()
                        .HasDatabaseName("IX_cvx_visname_visdate");

                    b.ToTable("CdcCvxVises");
                });

            modelBuilder.Entity("Domain.CDC.CdcLookupBarcode", b =>
                {
                    b.Property<int>("CdcBarcodeLookupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcBarcodeLookupId"));

                    b.Property<DateOnly>("EditionDate")
                        .HasColumnType("date");

                    b.Property<string>("EditionStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateOnly>("LateUpdateDate")
                        .HasColumnType("date");

                    b.Property<string>("VisDocumentTypeDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("VisFullyEncodedString")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VisGdtiCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CdcBarcodeLookupId");

                    b.HasAlternateKey("VisFullyEncodedString")
                        .HasName("IX_encodedString");

                    b.ToTable("CdcLoopupBarcodes");
                });

            modelBuilder.Entity("Domain.CDC.CdcLookupNdc", b =>
                {
                    b.Property<int>("CdcLookupNdc10Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CdcLookupNdc10Id"));

                    b.Property<string>("CdcCvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CptCode")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("CptLongDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CptShortDescription")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CptStatus")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateOnly?>("CvxEddectiveDate")
                        .HasColumnType("date");

                    b.Property<string>("CvxLongDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly?>("CvxRetiredDate")
                        .HasColumnType("date");

                    b.Property<string>("CvxShortDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CvxStatus")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MvxCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MvxStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly?>("SaleEndDate")
                        .HasColumnType("date");

                    b.Property<string>("SaleGtin")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SaleLabeler")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("SaleLastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("SaleNdc10")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SaleNdc11")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("SalePackageForm")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SaleProprietaryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly?>("SaleStatDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("UseEndDate")
                        .HasColumnType("date");

                    b.Property<string>("UseGtin")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UseNdc10")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UseNdc11")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateOnly?>("UseStartDate")
                        .HasColumnType("date");

                    b.Property<string>("UseUnitPackerForm")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("UserLastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("VaccineSeason")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CdcLookupNdc10Id");

                    b.HasIndex("SaleNdc11", "SaleNdc10", "UseNdc11", "UseNdc10", "CdcCvxCode", "MvxCode")
                        .IsUnique()
                        .HasDatabaseName("IX_ndc11_ndc10_cvx_mvx")
                        .HasFilter("[SaleNdc10] IS NOT NULL");

                    b.ToTable("CdcLookupNdcs");
                });

            modelBuilder.Entity("Domain.CDC.CdcManufacturer", b =>
                {
                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("LastUpdateDate")
                        .HasColumnType("date");

                    b.Property<string>("ManufacturerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ManufacturerNotes")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ManufacturerStatus")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("MvxCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("ManufacturerId");

                    b.HasAlternateKey("MvxCode");

                    b.ToTable("CdcManufacturers");
                });
#pragma warning restore 612, 618
        }
    }
}