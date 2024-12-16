using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CDC
{
    public class CdcManufacturer
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/mvx.txt

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] // from downloaded file
        public int ManufacturerId { get; set; }
        
        [MaxLength(5)] 
        public required string MvxCode { get; set; }
        [MaxLength(100)] 
        public required string ManufacturerName { get; set; }
        [MaxLength(200)] 
        public string? ManufacturerNotes { get; set; }
        [MaxLength(15)] 
        public required string ManufacturerStatus { get; set; }
        public DateOnly LastUpdateDate { get; set; }
    }
}
