using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvxVis
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/cvx_vis.txt

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcVisId { get; set; }
        
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        [MaxLength(100)] 
        public required string CvxVaccineDescription { get; set; }
        public required int VisFullyEncodedTextString { get; set; }
        [MaxLength(100)]
        public required string VisDocumentName { get; set; }
        [Required(ErrorMessage = "Vis Edition date missing")]
        public DateOnly? VisEditionDate { get; set; }
        [MaxLength(15)] 
        public required bool VisEditionStatus { get; set; }
    }
}
