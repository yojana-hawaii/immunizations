using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Cdc;

public class CdcCvxManufacturer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CdcCvxManufacturerId { get; set; }

    [MaxLength(100)]
    public required string CdcProductName { get; set; }
    [MaxLength(100)]
    public required string ShortDescription { get; set; }
    [MaxLength(5)]
    public required string CdcCvxCode { get; set; }
    [MaxLength(100)]
    public string? Manufacturer { get; set; }
    [MaxLength(5)]
    public string? MvxCode { get; set; }
    [MaxLength(15)]
    public required string MvxStatus { get; set; }
    [MaxLength(15)]
    public required string ProductNameStatus { get; set; }
    public required DateOnly LastUpdatedDate { get; set; }

    public static bool CdcFetchComparer(CdcCvxManufacturer item, CdcCvxManufacturer other)
    {
        return item.LastUpdatedDate == other.LastUpdatedDate;
    }
}
