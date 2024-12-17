using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class VaccinePrograms
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VaccineProgramId { get; set; }

        [MaxLength(20)]
        public required string VaccineProgram { get; set; }
        [MaxLength(100)]
        public required string VaccineProgramDescription { get; set; }
    }

}
