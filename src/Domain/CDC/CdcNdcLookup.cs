using System.ComponentModel.DataAnnotations;

namespace Domain.CDC
{
    public class CdcNdcLookup
    {
        // pull from https://www2a.cdc.gov/vaccines/iis/iisstandards/downloads/NDC/get_all_ndc_display.txt
        [Key]
        public int CdcNdcCrosswalkId { get; set; }
        public int SequenceNumber { get; set; }
        public string SaleNDC11 { get; set; }
        public string SaleProrietaryName { get; set; }
        public string SaleLabeler { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int SaleGTIN { get; set; }
        public DateOnly SaleLastUpdate { get; set; }
        public string UseNDC11 { get; set; }
        public string NoUseNDC { get; set; }
        public int UseGTIN { get; set; }
        public DateOnly UseLastUpdate { get; set; }
        public int CdcCvxCode { get; set; }
        public string CVXDescription { get; set; }
        public string MVXCode { get; set; }
    }
}
