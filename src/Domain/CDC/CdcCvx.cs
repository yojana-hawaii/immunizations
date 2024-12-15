using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcCvx
    {
        // pull from https://www2a.cdc.gov/vaccines/IIS/IISStandards/downloads/cvx.txt
        [Key]
        public int CdcCvxId { get; set; }
        
        [Display(Name = "CDC CVX Code")]
        [Required(ErrorMessage = "CDC CVX Code missing.")]
        [MaxLength(5)]
        public required string CdcCvxCode { get; set; }
        
        [Display(Name = "CDC CVX Short Description")]
        [Required(ErrorMessage = "CDC CVX Short Description missing")]
        [MaxLength(100)]
        public required string ShortDescription { get; set; }
        
        [Display(Name = "Full Vaccine Name from CDC")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(500)]
        public string? FullVaccineName { get; set; }
        
        [Display(Name = "CVX Notes from CDC")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(500)]
        public string? Notes { get; set; }
        
        [Display(Name = "Vaccine Status")]
        [Required(ErrorMessage = "Missing vaccine status")]
        [MaxLength(15)]
        public required string VaccineStatus { get; set; }
        
        [Display(Name = "CDC CVX Last Update Date")]
        [Required(AllowEmptyStrings = true)]
        public required DateOnly LastUpdatedDate { get; set; }
    }
}
