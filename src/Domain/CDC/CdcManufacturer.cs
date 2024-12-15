using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcManufacturer
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/mvx.txt

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcManufacturerId { get; set; }
        
        [MaxLength(5)] 
        public required string MvxCode { get; set; }
        [MaxLength(100)] 
        public required string ManufacturerName { get; set; }
        [MaxLength(200)] 
        public string? ManufacturerNotes { get; set; }
        [MaxLength(15)] 
        public required string ManufacturerStatus { get; set; }
        public required DateOnly LastUpdateDate { get; set; }
        [MaxLength(5)] 
        public int? ManufacturerId { get; set; }
    }
}
