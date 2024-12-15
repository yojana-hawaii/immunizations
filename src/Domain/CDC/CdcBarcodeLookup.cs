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
        
        [Display(Name = "Vis Document Type Description")]
        [Required(ErrorMessage = "Vis Document Type Description missing")]
        [MaxLength(100)] 
        public required string VisDocumentTypeDescription { get; set; }
        
        [Display(Name = "Edition Date")]
        [Required(ErrorMessage = "Edition date missing")]
        public required DateOnly EditionDate { get; set; }
        
        [Display(Name = "Vis Fully Encoded String")]
        [Required(ErrorMessage = "Vis fully encoded string missing")]
        public required int VisFullyEncodedString { get; set; }
        
        [Display(Name = "Vis GDTI Document Code")]
        [Required(ErrorMessage = "Vis GDTI document code missing")]
        public required int VisGdtiCode { get; set; }
        
        [Display(Name = "Edition Status")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(15)] 
        public string? EditionStatus { get; set; }
        
        [Display(Name = "Last Update Date")]
        [Required(ErrorMessage = "Last Update date missing")]
        public required DateOnly LateUpdateDate { get; set; }
    }
}
