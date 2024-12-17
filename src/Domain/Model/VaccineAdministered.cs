using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class VaccineAdministered
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VaccineAdministeredId { get; set; }

        public required int PID { get; set; }
        [MaxLength(50)]
        public required string AdministeredBy { get; set; }
        public required DateTime AdministeredDate { get; set; }
        [MaxLength(200)]
        public string? AdministtrationComment { get; set; }
    }
}
