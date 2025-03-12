using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Cdc;

public class CdcLookupBarcode : AuditableEntity, IEquatable<CdcLookupBarcode>
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(100)]
    public required string VisDocumentTypeDescription { get; set; }
    public DateOnly EditionDate { get; set; }
    [StringLength(50)]
    public required string VisFullyEncodedString { get; set; }
    [StringLength(50)]
    public required string VisGdtiCode { get; set; }
    [StringLength(15)]
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
