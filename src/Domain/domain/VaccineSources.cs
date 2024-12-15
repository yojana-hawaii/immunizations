using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.domain
{
    public class VaccineSources
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VaccineSourceId { get; set; }

        [MaxLength(10)]
        public required string VaccineSource { get; set; }
        [MaxLength(100)]
        public required string VaccineSourceDescription { get; set; }
    }
}
