using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvx
    {
        // pull from https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt
        [Key]
        public int CdcCvxId { get; set; }
        public string CdcCvxCode { get; set; }
        public string ShortDescription { get; set; }
        public string FullVaccineName { get; set; }
        public string Notes { get; set; }
        public string VaccineStatus { get; set; }
        public DateOnly LastUpdatedDate { get; set; }
    }
}
