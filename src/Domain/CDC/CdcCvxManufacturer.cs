using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvxManufacturer
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/TRADENAME.txt
        [Key]
        public int CdcCvxManufacturerId { get; set; }
        
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Product name missing")]
        [MaxLength(50)] 
        public required string CdcProductName { get; set; }
        
        [Display(Name = "Short Description")]
        [Required(ErrorMessage = "description missing")]
        [MaxLength(100)] 
        public required string ShortDescription { get; set; }
        
        [Display(Name = "CDC CVX Code")]
        [Required(ErrorMessage = "CDC CVS Code missing")]
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        
        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Manufacturer missing")]
        [MaxLength(50)] 
        public required string Manufacturer { get; set; }
        
        [Display(Name = "MVX Code")]
        [Required(ErrorMessage = "MVX Code missing")]
        [MaxLength(5)] 
        public required string MvxCode { get; set; }
        
        [Display(Name = "MVX Status")]
        [Required(ErrorMessage = "MVX Status missing")]
        [MaxLength(15)] 
        public required string MvxStatus { get; set; }
        
        [Display(Name = "Product Status")]
        [Required(ErrorMessage = "Product Status missing")]
        [MaxLength(15)] 
        public required string ProductNameStatus { get; set; }
        
        [Display(Name = "Last Update Date")]
        [Required(ErrorMessage = "Missing Last update date")]
        public required DateOnly LastUpdatedDate { get; set; }
    }
}
