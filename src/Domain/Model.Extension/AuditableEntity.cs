namespace Domain.Model.Extension;

public class AuditableEntity
{
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
