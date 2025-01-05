using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class LotNumber
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VaccineLotNumberId { get; set; }

    [MaxLength(15)]
    public required string VaccineLotNumber { get; set; }
    public required DateOnly VaccineExpirationDate { get; set; }
}
