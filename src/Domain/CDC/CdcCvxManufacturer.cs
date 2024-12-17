using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.CDC
{
    public class CdcCvxManufacturer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CdcCvxManufacturerId { get; set; }
        
        [MaxLength(50)] 
        public required string CdcProductName { get; set; }
        [MaxLength(100)] 
        public required string ShortDescription { get; set; }
        [MaxLength(5)] 
        public required string CdcCvxCode { get; set; }
        [MaxLength(50)] 
        public string? Manufacturer { get; set; }
        [MaxLength(5)] 
        public string? MvxCode { get; set; }
        [MaxLength(15)] 
        public required string MvxStatus { get; set; }
        [MaxLength(15)] 
        public required string ProductNameStatus { get; set; }
        public required DateOnly LastUpdatedDate { get; set; }
    }
}
