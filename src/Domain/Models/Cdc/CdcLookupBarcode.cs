using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcLookupBarcode : IEquatable<CdcLookupBarcode>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcBarcodeLookupId { get; set; }

    [MaxLength(100)]
    public required string VisDocumentTypeDescription { get; set; }
    public DateOnly EditionDate { get; set; }
    [MaxLength(50)]
    public required string VisFullyEncodedString { get; set; }
    [MaxLength(50)]
    public required string VisGdtiCode { get; set; }
    [MaxLength(15)]
    public required string EditionStatus { get; set; }
    public DateOnly LateUpdatedDate { get; set; }



    public static bool CdcFetchComparer(CdcLookupBarcode item, CdcLookupBarcode other)
    {
        return item.LateUpdatedDate == other.LateUpdatedDate;
    }
    public bool Equals(CdcLookupBarcode? other)
    {
        if(other is null) return false; 
        if(ReferenceEquals(this, other)) return true;
        return this.VisFullyEncodedString == VisFullyEncodedString;
    }

    public override bool Equals(object? obj) => Equals(obj as CdcLookupBarcode);
    public override int GetHashCode() => VisFullyEncodedString.GetHashCode();

}
