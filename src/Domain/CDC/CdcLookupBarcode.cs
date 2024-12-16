using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CDC
{
    public class CdcLookupBarcode
    {
        /* pull from https://www.cdc.gov/iis/code-sets/vis-barcode-lookup-table.html
         * txt and xml not working
         * pull excel file https://www.cdc.gov/iis/code-sets/downloads/vis-barcode-lookup-table.xlsx
         */


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcBarcodeLookupId { get; set; }
        
        [MaxLength(100)] 
        public required string VisDocumentTypeDescription { get; set; }
        public DateOnly EditionDate { get; set; }
        [MaxLength(50)]
        public required string VisFullyEncodedString { get; set; }
        [MaxLength(50)]
        public required string VisGdtiCode { get; set; }
        [MaxLength(15)] 
        public required string EditionStatus { get; set; }
        public DateOnly LateUpdateDate { get; set; }
    }
}
