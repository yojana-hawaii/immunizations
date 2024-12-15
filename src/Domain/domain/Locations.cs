using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.domain
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
