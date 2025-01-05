using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class VaccineGroup
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VaccineGroupId { get; set; }

    [MaxLength(5)]
    public required string VaccineGroupCvxCode { get; set; }
    [MaxLength(100)]
    public required string VaccineGroupName{ get; set; }
    [MaxLength(500)]
    public string? VaccineGroupDescription { get; set; }
    public required DateOnly VisDate { get; set; }
}
