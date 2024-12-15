using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.domain
{
    public class LotNumbers
    {
        [Key]
        public int LotNumberId { get; set; }

        [Display(Name = "Vaccine Lot Number")]
        [Required(ErrorMessage = "Lot number missing")]
        [MaxLength(15)]
        public required string LotNumber { get; set; }

        [Display(Name = "Vaccine Expiration Date")]
        [Required(ErrorMessage = "Expiration Date missing")]
        public required DateOnly ExpirationDate { get; set; }
    }
}
