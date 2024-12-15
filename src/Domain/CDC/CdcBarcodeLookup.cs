using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CDC
{
    public class CdcBarcodeLookup
    {
        /* pull from https://www.cdc.gov/iis/code-sets/vis-barcode-lookup-table.html
         * txt and xml not working
         * pull excel file https://www.cdc.gov/iis/code-sets/downloads/vis-barcode-lookup-table.xlsx
         */
        [Key]
        public int CdcBarcodeLookupId { get; set; }
        public string Description { get; set; }
        public DateOnly EditionDate { get; set; }
        public int VisFullyEncodedString { get; set; }
        public int VisGdtiCode { get; set; }
        public string EditionStatus { get; set; }
        public DateOnly LateUpdateDate { get; set; }
    }
}
