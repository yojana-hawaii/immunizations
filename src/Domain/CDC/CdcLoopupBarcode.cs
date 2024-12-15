using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcLoopupBarcode
    {
        /* pull from https://www.cdc.gov/iis/code-sets/vis-barcode-lookup-table.html
         * txt and xml not working
         * pull excel file https://www.cdc.gov/iis/code-sets/downloads/vis-barcode-lookup-table.xlsx
         */


        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcBarcodeLookupId { get; set; }
        
        [MaxLength(100)] 
        public required string VisDocumentTypeDescription { get; set; }
        public required DateOnly EditionDate { get; set; }
        public required int VisFullyEncodedString { get; set; }
        public required int VisGdtiCode { get; set; }
        [MaxLength(15)] 
        public string? EditionStatus { get; set; }
        public required DateOnly LateUpdateDate { get; set; }
    }
}
