using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcCvxCpt : AuditableEntity, IEquatable<CdcCvxCpt>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(10)]
    public required string CptCode { get; set; }
    [StringLength(500)]
    public required string CptDescription { get; set; }
    [StringLength(5)]
    public required string CdcCvxCode { get; set; }
    [StringLength(500)]
    public required string CvxDescription { get; set; }
    [StringLength(500)]
    public string? Comments { get; set; }
    public DateOnly LastUpdatedDate { get; set; }

    [StringLength(20)]
    public string? CptCodeId { get; set; }


    public static bool CdcFetchComparer(CdcCvxCpt item, CdcCvxCpt other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }

    public bool Equals(CdcCvxCpt? other)
    {
        if (other is null) return false;
        if(ReferenceEquals(null, other)) return false;
        return this.CdcCvxCode == other.CdcCvxCode && this.CptCode == other.CptCode;
    }
    public override bool Equals(object? obj) => Equals(obj as CdcCvxCpt);
    public override int GetHashCode()
    {
        return (CdcCvxCode, CptCode).GetHashCode();
    }
}
