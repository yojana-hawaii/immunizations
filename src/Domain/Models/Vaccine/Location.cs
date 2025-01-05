using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Vaccine;

public class Location
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LocationId { get; set; }

    [MaxLength(100)]
    public required string LocationName { get; set; }
    [MaxLength(100)]
    public string? SubLocation { get; set; }
}
