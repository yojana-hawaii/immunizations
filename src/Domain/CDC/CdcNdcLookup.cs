using System.ComponentModel.DataAnnotations;

namespace Domain.CDC
{
    public class CdcNdcLookup
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/NDC/get_all_ndc_display.txt
        [Key]
        public int CdcNdcCrosswalkId { get; set; }
        
        [Display(Name = "Sequence Number")]
        [Required(ErrorMessage = "Sequence number missing")]
        public required int SequenceNumber { get; set; }
        
        [Display(Name = "Sale NDC-11")]
        [Required(ErrorMessage = "Sale NDC-11 missing")]
        [MaxLength(15)] 
        public required string SaleNDC11 { get; set; }
        
        [Display(Name = "Sale Proprietary Name")]
        [Required(ErrorMessage = "Sale proprietary name missing")]
        [MaxLength(100)] 
        public required string SaleProrietaryName { get; set; }
        
        [Display(Name = "Sale Labeler")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(50)] 
        public string? SaleLabeler { get; set; }
        
        [Display(Name = "Start Date")]
        [Required(AllowEmptyStrings = true)]
        public required DateOnly StartDate { get; set; }
        
        [Display(Name = "End Date")]
        [Required(AllowEmptyStrings = true)]
        public DateOnly? EndDate { get; set; }
        
        [Display(Name = "Sale GTIN")]
        [Required(ErrorMessage = "Sale GTIN missing")]
        public required int SaleGTIN { get; set; }
        
        [Display(Name = "Sale Last Update Date")]
        [Required(ErrorMessage = "Sale Last update date missing")]
        public required DateOnly SaleLastUpdate { get; set; }
        
        [Display(Name = "Use NDC-11")]
        [Required(ErrorMessage = "")]
        [MaxLength(15)] 
        public required string UseNDC11 { get; set; }
        
        [Display(Name = "No Use NDC")]
        [Required(ErrorMessage = "No Use NDC missing")]
        public required bool NoUseNDC { get; set; }
        
        [Display(Name = "Use GTIN")]
        [Required(ErrorMessage = "Use GTIN missing")]
        public required int UseGTIN { get; set; }
        
        [Display(Name = "Use Last Update")]
        [Required(ErrorMessage = "Use Last Update missing")]
        public required DateOnly UseLastUpdate { get; set; }
        
        [Display(Name = "CDC CVX Code")]
        [Required(ErrorMessage = "CDC CVX Code missing")]
        [MaxLength(5)]
        public required string CdcCvxCode { get; set; }
        
        [Display(Name = "CVX Description")]
        [Required(ErrorMessage = "CXV Description missing")]
        [MaxLength(100)] 
        public required string CVXDescription { get; set; }
        
        [Display(Name = "MVX Code")]
        [Required(ErrorMessage = "MVX Code missing")]
        [MaxLength(5)] 
        public required string MVXCode { get; set; }
    }
}
