using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcLookupBarcode
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
    public DateOnly LateUpdateDate { get; set; }
}
