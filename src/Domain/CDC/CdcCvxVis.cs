using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int VisFullyEncodedTextString { get; set; }
        [MaxLength(100)]
        public required string VisDocumentName { get; set; }
        public DateOnly VisEditionDate { get; set; }
        [MaxLength(15)] 
        public bool VisEditionStatus { get; set; }
    }
}
