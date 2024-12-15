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
        public string CdcProductName { get; set; }
        public string ShortDescription { get; set; }
        public string CdcCvxCode { get; set; }
        public string Manufacturer { get; set; }
        public string MvxCode { get; set; }
        public string MvxStatus { get; set; }
        public string ProductNameStatus { get; set; }
        public DateOnly LastUpdatedDate { get; set; }
    }
}
