
namespace Domain.Utility.CollectionHelper;

public class CollectionComparisionResult<T>
{
    public required IEnumerable<T> Added { get; set; }
    public required IEnumerable<T> Removed { get; set; }
    public required IEnumerable<T> Unchanged { get; set; }
    public required IEnumerable<T> Changed { get; set; }

}
