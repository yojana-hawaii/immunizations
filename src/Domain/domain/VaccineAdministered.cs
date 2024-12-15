using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.domain
{
    public class VaccineAdministered
    {
        [Key]
        public int VaccineAdministeredId { get; set; }

        [Display(Name = "Patient ID")]
        [Required(ErrorMessage = "Patient ID missing")]
        public required int PID { get; set; }

        [Display(Name = "Vaccine Administered By")]
        [Required(ErrorMessage = "Administered username missing")]
        [MaxLength(50)]
        public required string AdministeredBy { get; set; }

        [Display(Name = "Vaccine Administered Date")]
        [Required(ErrorMessage = "Administered date missing")]
        public required DateTime AdministeredDate { get; set; }

        [Display(Name = "Vaccine Administration Comment")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(200)]
        public string? AdministtrationComment { get; set; }
    }
}
