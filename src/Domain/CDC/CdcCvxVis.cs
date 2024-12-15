using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvxVis
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cvx_vis.txt
        [Key]
        public int CdcVisId { get; set; }
        
        [Display(Name = "CDC CVX Code")]
        [Required(ErrorMessage = "CDC CVX Code Missing")]
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        
        [Display(Name = "Vaccine Description")]
        [Required(ErrorMessage = "Vaccine Description missing")]
        [MaxLength(100)] 
        public required string CvxVaccineDescription { get; set; }
        
        [Display(Name = "Vis Encoded String")]
        [Required(ErrorMessage = "Vis Encoded string missing")]
        public required int VisFullyEncodedTextString { get; set; }
        
        [Display(Name = "Vis Document Name")]
        [Required(ErrorMessage = "Document name missing")]
        [MaxLength(100)]
        public required string VisDocumentName { get; set; }
        
        [Display(Name = "Vis Edition Date")]
        [Required(ErrorMessage = "Vis Edition date missing")]
        public DateOnly? VisEditionDate { get; set; }
        
        [Display(Name = "Vis Edition Status")]
        [Required(ErrorMessage = "missing vaccine status")]
        [MaxLength(15)] 
        public required bool VisEditionStatus { get; set; }
    }
}
