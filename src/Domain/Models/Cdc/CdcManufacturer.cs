using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcManufacturer : IEquatable<CdcManufacturer>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // from downloaded file
    public int ManufacturerId { get; set; }

    [MaxLength(5)]
    public required string MvxCode { get; set; }
    [MaxLength(100)]
    public required string ManufacturerName { get; set; }
    [MaxLength(200)]
    public string? ManufacturerNotes { get; set; }
    [MaxLength(15)]
    public required string ManufacturerStatus { get; set; }
    public DateOnly LastUpdatedDate { get; set; }



    public static bool CdcFetchComparer(CdcManufacturer item, CdcManufacturer other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }
    public bool Equals(CdcManufacturer? other)
    {
        if (other is null) return false;
        if(ReferenceEquals(this, other)) return true;
        return this.MvxCode == other.MvxCode;
    }
    public override bool Equals(object? obj) => Equals(obj as CdcManufacturer);
    public override int GetHashCode() => MvxCode.GetHashCode();
}
