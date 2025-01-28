using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcLookupNdc : AuditableEntity, IEquatable<CdcLookupNdc>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcLookupNdc10Id { get; set; }

    [MaxLength(15)]
    public required string SaleNdc11 { get; set; }
    [MaxLength(15)]
    public string? SaleNdc10 { get; set; }
    [MaxLength(15)]
    public required string UseNdc11 { get; set; }
    [MaxLength(15)]
    public required string UseNdc10 { get; set; }
    [MaxLength(100)]
    public required string SaleProprietaryName { get; set; }
    [MaxLength(100)]
    public required string SaleLabeler { get; set; }
    [MaxLength(100)]
    public string? SalePackageForm { get; set; }
    [MaxLength(50)]
    public required string Route { get; set; }
    public DateOnly? SaleStatDate { get; set; }
    public DateOnly? SaleEndDate { get; set; }
    [MaxLength(50)]
    public string? SaleGtin { get; set; }
    public DateOnly SaleLastUpdated { get; set; }
    [MaxLength(50)]
    public string? VaccineSeason { get; set; }
    [MaxLength(100)]
    public string? UseUnitPackerForm { get; set; }
    public DateOnly? UseStartDate { get; set; }
    public DateOnly? UseEndDate { get; set; }
    [MaxLength(50)]
    public string? UseGtin { get; set; }
    public DateOnly UserLastUpdated { get; set; }
    [MaxLength(5)]
    public required string CdcCvxCode { get; set; }
    [MaxLength(100)]
    public required string CvxShortDescription { get; set; }
    [MaxLength(500)]
    public required string CvxLongDescription { get; set; }
    [MaxLength(15)]
    public required string CvxStatus { get; set; }
    public DateOnly? CvxEffectiveDate { get; set; }
    public DateOnly? CvxRetiredDate { get; set; }
    [MaxLength(20)]
    public required string MvxCode { get; set; }
    [MaxLength(100)]
    public required string Manufacturer { get; set; }
    [MaxLength(15)]
    public required string MvxStatus { get; set; }
    [MaxLength(15)]
    public string? CptCode { get; set; }
    [MaxLength(50)]
    public string? CptShortDescription { get; set; }
    [MaxLength(500)]
    public string? CptLongDescription { get; set; }
    [MaxLength(15)]
    public string? CptStatus { get; set; }

    public static bool CdcFetchComparer(CdcLookupNdc item, CdcLookupNdc other)
    {
        return item.SaleLastUpdated == other.SaleLastUpdated && item.UserLastUpdated == other.UserLastUpdated;
    }

    public bool Equals(CdcLookupNdc? other)
    {
        if (other is null) return false;
        if(ReferenceEquals(other, this)) return true;

        return this.SaleNdc10 == other.SaleNdc10 && this.SaleNdc11 == other.SaleNdc11
                && this.UseNdc10 == other.UseNdc10 && this.UseNdc11 == other.UseNdc11
                && this.CptCode == other.CptCode
                && this.CdcCvxCode == other.CdcCvxCode && this.MvxCode == other.MvxCode;
    }
    public override bool Equals(object? obj) => Equals(obj as CdcLookupNdc);
    public override int GetHashCode() => (SaleNdc10, SaleNdc11, UseNdc10, UseNdc11, CdcCvxCode, MvxCode).GetHashCode();
}
