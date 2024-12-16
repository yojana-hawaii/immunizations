using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CDC
{
    public class CdcCvxVaccineGroup
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/VG.txt

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcCvxVaccineGroupId { get; set; }
        
        [MaxLength(100)]
        public required string ShortDescription { get; set; }
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        [MaxLength(15)]
        public required string VaccineStatus { get; set; }
        [MaxLength(100)] 
        public required string VaccineGroupName { get; set; }
        [MaxLength(5)] 
        public required string VaccineGroupCvxCode { get; set; }
    }
}
