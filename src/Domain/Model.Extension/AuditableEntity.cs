using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Extension;

public abstract class AuditableEntity : IAuditable
{
    [ScaffoldColumn(false)] //don't bother with in user interface scaffolding
    [StringLength(100)]
    public string? CreatedBy { get; set; }

    [ScaffoldColumn(false)]
    [StringLength(100)]
    public string? ModifiedBy { get; set; }

    [ScaffoldColumn(false)]
    public DateTime? CreatedDate { get; set; }

    [ScaffoldColumn(false)]
    public DateTime? ModifiedDate { get; set; }
}
