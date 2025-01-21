using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TypoOnEffectiveDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CvxEddectiveDate",
                table: "CdcLookupNdcs",
                newName: "CvxEffectiveDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CvxEffectiveDate",
                table: "CdcLookupNdcs",
                newName: "CvxEddectiveDate");
        }
    }
}
