using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcManufacturer : AuditableEntity, IEquatable<CdcManufacturer>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // from downloaded file
    public int Id { get; set; }

    [StringLength(5)]
    public required string MvxCode { get; set; }
    [StringLength(100)]
    public required string ManufacturerName { get; set; }
    [StringLength(200)]
    public string? ManufacturerNotes { get; set; }
    [StringLength(15)]
    public required string ManufacturerStatus { get; set; }
    public DateOnly LastUpdatedDate { get; set; }



    public static bool CdcFetchComparer(CdcManufacturer item, CdcManufacturer other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }
    public bool Equals(CdcManufacturer? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return this.MvxCode == other.MvxCode;
    }
    public override bool Equals(object? obj) => Equals(obj as CdcManufacturer);
    public override int GetHashCode() => MvxCode.GetHashCode();
}
