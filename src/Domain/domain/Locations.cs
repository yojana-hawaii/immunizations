using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.domain
{
    public class Locations
    {
        [Key]
        public int LocationId { get; set; }

        [Display(Name = "Main Location")]
        [Required(ErrorMessage = "Main Location is required.")]
        [MaxLength(100)]
        public required string Location { get; set; }

        [Display(Name = "Sub Location")]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(100)]
        public string? SubLocation { get; set; }
    }
}
