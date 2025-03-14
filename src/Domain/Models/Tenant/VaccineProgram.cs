using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Model.Extension;

namespace Domain.Models.Tenant;

public class VaccineProgram : AuditableEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Cannot leave {0} blank")]
    [StringLength(50, ErrorMessage = "{0} cannot exceed {1} characters")]
    [Display(Name = "Vaccine Program")]
    public string VaccineProgramName { get; set; } = "";


    [StringLength(100, ErrorMessage = "{0} cannot exceed {1} characters")]
    [Display(Name = "Description")]
    public string? VaccineProgramDescription { get; set; }
}
