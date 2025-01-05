using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class VaccineBrand
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VaccindBrandId { get; set; }

    [MaxLength(5)]
    public required string VaccineBrandCvxCode { get; set; }
    [MaxLength(50)]
    public required string VaccineBrandName { get; set; }
    [MaxLength(50)]
    public required string VaccineBrandManufacturer { get; set; }
    [MaxLength(15)]
    public required string SaleNdc { get; set; }
    [MaxLength(15)]
    public required string UseNdc { get; set; }
}
