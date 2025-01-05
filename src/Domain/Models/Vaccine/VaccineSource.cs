using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class VaccineSource
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VaccineSourceId { get; set; }

    [MaxLength(10)]
    public required string VaccineSourceName { get; set; }
    [MaxLength(100)]
    public required string VaccineSourceDescription { get; set; }
}
