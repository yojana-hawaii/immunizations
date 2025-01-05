using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcCvxVaccineGroup
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcCvxVaccineGroupId { get; set; }

    [MaxLength(100)]
    public required string ShortDescription { get; set; }
    [MaxLength(5)]
    public required string CdcCvxCode { get; set; }
    [MaxLength(15)]
    public required string VaccineStatus { get; set; }
    [MaxLength(100)]
    public required string VaccineGroupName { get; set; }
    [MaxLength(5)]
    public required string VaccineGroupCvxCode { get; set; }
}
