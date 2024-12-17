using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class VaccineBrands
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VaccindBrandId { get; set; }

        [MaxLength(5)]
        public required string VaccineBrandCvxCode { get; set; }
        [MaxLength(50)]
        public required string VaccindBrand { get; set; }
        [MaxLength(50)]
        public required string VaccineBrandManufacturer { get; set; }
        [MaxLength(15)]
        public required string SaleNdc { get; set; }
        [MaxLength(15)]
        public required string UseNdc { get; set; }
    }
}
