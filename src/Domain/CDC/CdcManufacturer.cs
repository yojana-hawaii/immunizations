using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcManufacturer
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/mvx.txt
        [Key]
        public int CdcManufacturerId { get; set; }
        
        [Display(Name = "MVX Code")]
        [Required(ErrorMessage = "MVX Code missing")]
        [MaxLength(5)] 
        public required string MvxCode { get; set; }
        
        [Display(Name = "Manufacturer Name")]
        [Required(ErrorMessage = "Manufacturer Name missing")]
        [MaxLength(100)] 
        public required string ManufacturerName { get; set; }
        
        [Display(Name = "Manufacturer Note")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(200)] 
        public string? ManufacturerNotes { get; set; }
        
        [Display(Name = "Manufacturer Status")]
        [Required(ErrorMessage = "Manufacturer status missing")]
        [MaxLength(15)] 
        public required string ManufacturerStatus { get; set; }
        
        [Display(Name = "Last Update Date")]
        public required DateOnly LastUpdateDate { get; set; }
        
        [Display(Name = "Manufacturer ID")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(5)] 
        public int? ManufacturerId { get; set; }
    }
}
