using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.domain
{
    public class VaccineGroups
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VaccineGroupId { get; set; }

        [MaxLength(5)]
        public required string VaccineGroupCvxCode { get; set; }
        [MaxLength(100)]
        public required string VaccineGroup { get; set; }
        [MaxLength(500)]
        public string? VaccineGroupDescription { get; set; }
        public required DateOnly VisDate { get; set; }
    }
}
