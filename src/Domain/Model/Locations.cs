using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Locations
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }

        [MaxLength(100)]
        public required string Location { get; set; }
        [MaxLength(100)]
        public string? SubLocation { get; set; }
    }
}
