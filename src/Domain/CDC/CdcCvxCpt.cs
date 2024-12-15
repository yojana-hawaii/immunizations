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
        public string CptCode { get; set; }
        public string CptDescription { get; set; }
        public string CdcCvxCode { get; set; }
        public string Vaccinename { get; set; }
        public string Comments { get; set; }
        public DateOnly LateUpdatedDate { get; set; }
    }
}
