using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcManufacturer
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
    public DateOnly LastUpdateDate { get; set; }
}
