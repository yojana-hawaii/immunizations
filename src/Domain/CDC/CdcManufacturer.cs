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
        public string MvxCode { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerNotes { get; set; }
        public string ManufacturerStatus { get; set; }
        public DateOnly LastUpdateDate { get; set; }
        public int ManufacturerId { get; set; }
    }
}
