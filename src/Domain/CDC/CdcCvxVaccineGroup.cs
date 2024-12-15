using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvxVaccineGroup
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/VG.txt
        [Key]
        public int CdcCvxVaccineGroupId { get; set; }
        
        [Display(Name = "Vaccine Group Short Descrption")]
        [Required(ErrorMessage = "Vaccine Group Description missing.")]
        [MaxLength(100)]
        public required string ShortDescription { get; set; }
        
        [Display(Name = "CDC CVX Code")]
        [Required(ErrorMessage = "CDC CVX Code missing")]
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        
        [Display(Name = "Vaccine Status")]
        [Required(ErrorMessage = "Missing vaccine status")]
        [MaxLength(15)]
        public required string VaccineStatus { get; set; }
        
        [Display(Name = "Vaccine Group Name")]
        [Required(ErrorMessage = "Vaccine group name missing")]
        [MaxLength(100)] 
        public required string VaccineGroupName { get; set; }
        
        [Display(Name = "Vaccine Group CVX Code")]
        [Required(ErrorMessage = "Vaccine Group CVX Code Missing")]
        [MaxLength(5)] 
        public required string VaccineGroupCvxCode { get; set; }
    }
}
