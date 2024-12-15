using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.domain
{
    public class LotNumbers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LotNumberId { get; set; }

        [MaxLength(15)]
        public required string LotNumber { get; set; }
        public required DateOnly ExpirationDate { get; set; }
    }
}
