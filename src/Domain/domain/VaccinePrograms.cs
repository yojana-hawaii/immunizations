using System.ComponentModel.DataAnnotations;

namespace Domain.domain
{
    public class VaccinePrograms
    {
        [Key]
        public int VaccineProgramId { get; set; }

        [Display(Name = "Vaccine Program")]
        [Required(ErrorMessage = "Missing Vaccine Program. Eg: Federal, State, Private, etc.")]
        [MaxLength(20)]
        public required string VaccineProgram { get; set; }

        [Display(Name = "Vaccine Program Description")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(100)]
        public required string VaccineProgramDescription { get; set; }
    }

}
