using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvx
    {
        // pull from https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcCvxId { get; set; }
        
        [MaxLength(5)]
        public required string CdcCvxCode { get; set; }
        [MaxLength(100)]
        public required string ShortDescription { get; set; }
        [MaxLength(500)]
        public string? FullVaccineName { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }
        [MaxLength(15)]
        public required string VaccineStatus { get; set; }
        public required DateOnly LastUpdatedDate { get; set; }
    }
}
