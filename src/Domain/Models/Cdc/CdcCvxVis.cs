using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcCvxVis
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcVisId { get; set; }

    [MaxLength(5)]
    public required string CdcCvxCode { get; set; }
    [MaxLength(100)]
    public required string CvxVaccineDescription { get; set; }
    public int VisFullyEncodedTextString { get; set; }
    [MaxLength(100)]
    public required string VisDocumentName { get; set; }
    public DateOnly VisEditionDate { get; set; }
    [MaxLength(15)]
    public bool VisEditionStatus { get; set; }
}
