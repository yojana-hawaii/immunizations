using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class VaccineProgram
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VaccineProgramId { get; set; }

    [MaxLength(20)]
    public required string VaccineProgramName { get; set; }
    [MaxLength(100)]
    public required string VaccineProgramDescription { get; set; }
}
