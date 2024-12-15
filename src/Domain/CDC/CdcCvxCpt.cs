using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvxCpt
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cpt.txt
        [Key]
        public int CdcCvxCptId { get; set; }
        
        [Display(Name = "CPT Code")]
        [Required(ErrorMessage = "CPT Code missing")]
        [MaxLength(10)] 
        public required string CptCode { get; set; }
        
        [Display(Name = "CPT Description")]
        [Required(ErrorMessage = "CPT Description missing")]
        [MaxLength(100)] 
        public required string CptDescription { get; set; }
        
        [Display(Name = "CDC CVX Code")]
        [Required(ErrorMessage = "CDC CVX Code missing")]
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        
        [Display(Name = "Vaccine Name")]
        [Required(ErrorMessage = "Vaccine name missing")]
        [MaxLength(100)] 
        public required string VaccineName { get; set; }
        
        [Display(Name = "Vaccine Comment")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(500)] 
        public string? Comments { get; set; }
        
        [Display(Name = "Last Update Date")]
        [Required(ErrorMessage = "Last update date missing")]
        public required DateOnly LateUpdatedDate { get; set; }
    }
}
