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
        public string CdcCvxCode { get; set; }
        public string CvxVaccineDescription { get; set; }
        public string VisFullyEncodedTextString { get; set; }
        public string VisDocumentName { get; set; }
        public DateOnly VisEditionDate { get; set; }
        public string VisEditionStatus { get; set; }
    }
}
