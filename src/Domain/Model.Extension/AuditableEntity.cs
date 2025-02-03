using System.ComponentModel.DataAnnotations;

namespace Domain.Model.Extension;

public abstract class AuditableEntity : IAuditable
{
    [ScaffoldColumn(false)] //don't bother with in user interface scaffolding
    public string? CreatedBy { get; set; }

    [ScaffoldColumn(false)]
    public string? ModifiedBy { get; set; }

    [ScaffoldColumn(false)]
    public DateTime? CreatedDate { get; set; }

    [ScaffoldColumn(false)]
    public DateTime? ModifiedDate { get; set; }
}
