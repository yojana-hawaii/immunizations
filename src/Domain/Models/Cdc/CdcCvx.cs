using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcCvx
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcCvxId { get; set; }

    [MaxLength(5)]
    public required string CdcCvxCode { get; set; }
    [MaxLength(100)]
    public required string ShortDescription { get; set; }
    [MaxLength(500)]
    public required string FullVaccineName { get; set; }
    [MaxLength(500)]
    public string? Notes { get; set; }
    [MaxLength(15)]
    public required string VaccineStatus { get; set; }
    public DateOnly LastUpdatedDate { get; set; }
}
