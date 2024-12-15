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
        public string ShortDescription { get; set; }
        public string CdcCvxCode { get; set; }
        public string VaccineStatus { get; set; }
        public string VaccineGroupName { get; set; }
        public string VaccineGroupCvxCode { get; set; }
    }
}
