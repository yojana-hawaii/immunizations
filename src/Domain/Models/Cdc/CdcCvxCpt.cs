using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcCvxCpt
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcCvxCptId { get; set; }

    [MaxLength(10)]
    public required string CptCode { get; set; }
    [MaxLength(500)]
    public required string CptDescription { get; set; }
    [MaxLength(5)]
    public required string CdcCvxCode { get; set; }
    [MaxLength(500)]
    public required string CvxDescription { get; set; }
    [MaxLength(500)]
    public string? Comments { get; set; }
    public DateOnly LastUpdatedDate { get; set; }

    [MaxLength(20)]
    public string? CptCodeId { get; set; }
}
