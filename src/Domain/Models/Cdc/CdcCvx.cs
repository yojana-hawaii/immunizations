using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcCvx : AuditableEntity, IEquatable<CdcCvx>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(5)]
    public required string CdcCvxCode { get; set; }
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

    public static bool CdcFetchComparer(CdcCvx item, CdcCvx other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }

    public bool Equals(CdcCvx? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return this.CdcCvxCode == other.CdcCvxCode;
    }

    public override bool Equals(object? obj) => Equals(obj as CdcCvx);
    public override int GetHashCode() => (CdcCvxCode).GetHashCode();
}
