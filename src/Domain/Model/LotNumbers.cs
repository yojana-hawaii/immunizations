using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
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
