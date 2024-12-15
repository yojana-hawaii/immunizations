using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CDC
{
    public class CdcLookupNdc
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/NDC/get_all_ndc_display.txt

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcNdcCrosswalkId { get; set; }
        
        public required int SequenceNumber { get; set; }
        [MaxLength(15)] 
        public required string SaleNDC11 { get; set; }
        [MaxLength(100)] 
        public required string SaleProrietaryName { get; set; }
        [MaxLength(50)] 
        public string? SaleLabeler { get; set; }
        public required DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public required int SaleGTIN { get; set; }
        public required DateOnly SaleLastUpdate { get; set; }
        [MaxLength(15)] 
        public required string UseNDC11 { get; set; }
        public required bool NoUseNDC { get; set; }
        public required int UseGTIN { get; set; }
        public required DateOnly UseLastUpdate { get; set; }
        [MaxLength(5)]
        public required string CdcCvxCode { get; set; }
        [MaxLength(100)] 
        public required string CVXDescription { get; set; }
        [MaxLength(5)] 
        public required string MVXCode { get; set; }
    }
}
