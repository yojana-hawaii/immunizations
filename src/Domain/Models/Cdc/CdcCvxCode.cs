using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcCvxCode : AuditableEntity, IEquatable<CdcCvxCode>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(5)]
    public required string CvxCode { get; set; }
    [StringLength(100)]
    public required string ShortDescription { get; set; }
    [StringLength(500)]
    public required string FullVaccineName { get; set; }
    [StringLength(500)]
    public string? Notes { get; set; }
    [StringLength(15)]
    public required string VaccineStatus { get; set; }
    public bool NonVaccine { get; set; }
    public DateOnly LastUpdatedDate { get; set; }

    public static bool CdcFetchComparer(CdcCvxCode item, CdcCvxCode other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }

    public bool Equals(CdcCvxCode? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return this.CvxCode == other.CvxCode;
    }

    public override bool Equals(object? obj) => Equals(obj as CdcCvxCode);
    public override int GetHashCode() => (CvxCode).GetHashCode();
}
