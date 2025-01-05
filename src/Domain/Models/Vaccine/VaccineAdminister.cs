using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class VaccineAdminister
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VaccineAdministeredId { get; set; }

    public required int PID { get; set; }
    [MaxLength(50)]
    public required string AdministeredBy { get; set; }
    public required DateTime AdministeredDate { get; set; }
    [MaxLength(200)]
    public string? AdministtrationComment { get; set; }
}
