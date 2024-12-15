using System.ComponentModel.DataAnnotations;

namespace Domain.domain
{
    public class VaccineGroup
    {
        [Key]
        public int VaccineGroupId { get; set; }

        [Display(Name = "Vaccine Group CVX Code")]
        [Required(ErrorMessage = "Vaccine Group cvx code missing")]
        [MaxLength(5)]
        public required string VaccineGroupCvxCode { get; set; }

        [Display(Name = "Vaccine Group Name")]
        [Required(ErrorMessage = "Vaccine Group name missing")]
        [MaxLength(100)]
        public required string VaccineGroupName { get; set; }

        [Display(Name = "Vaccine Group Description")]
        [Required(ErrorMessage = "Vaccine Group Description missing")]
        [MaxLength(500)]
        public string? VaccineGroupDescription { get; set; }

        [Display(Name = "Vis Date")]
        [Required(ErrorMessage = "Vis Date missing")]
        public required DateOnly VisDate { get; set; }
    }
}
