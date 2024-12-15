using System.ComponentModel.DataAnnotations;

namespace Domain.domain
{
    public class VaccineSources
    {
        [Key]
        public int VaccineSourceId { get; set; }

        [Display(Name = "Vaccine Source")]
        [Required(ErrorMessage = "Missing vaccine source. Eg: VFC, VFA etc")]
        [MaxLength(10)]
        public required string VaccineSource { get; set; }

        [Display(Name = "Vaccine Source Description")]
        [Required(ErrorMessage = "Vaccine source description missing. Eg: Vaccine For Children")]
        [MaxLength(100)]
        public required string VaccineSourceDescription { get; set; }
    }
}
