using System.ComponentModel.DataAnnotations;

namespace Domain.domain
{
    public class VaccineBrand
    {
        [Key]
        public int VaccindBrandId { get; set; }

        [Display(Name = "Vaccine Brand CVX Code")]
        [Required(ErrorMessage = "Vaccine brand CVS Code missing")]
        [MaxLength(5)]
        public required string VaccineBrandCvxCode { get; set; }

        [Display(Name = "Vaccine Brand Name")]
        [Required(ErrorMessage = "Brand name missing")]
        [MaxLength(50)]
        public required string VaccindBrandName { get; set; }

        [Display(Name = "Vaccine Brand Manufacturer")]
        [Required(ErrorMessage = "Vaccine brand manufacturer missing")]
        [MaxLength(50)]
        public required string VaccineBrandManufacturer { get; set; }

        [Display(Name = "Sale NDC")]
        [Required(ErrorMessage = "Sale NDC missing")]
        [MaxLength(15)]
        public required string SaleNdc { get; set; }

        [Display(Name = "Use NDC")]
        [Required(ErrorMessage = "Use NDC missing")]
        [MaxLength(15)]
        public required string UseNdc { get; set; }
    }
}
