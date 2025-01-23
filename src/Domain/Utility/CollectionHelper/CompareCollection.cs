namespace Domain.Utility.CollectionHelper;

public static class CompareCollection<T>
{

    public static CollectionComparisionResult<T> CompareLists(IEnumerable<T> oldList, 
                                                    IEnumerable<T> newList,
                                                    Func<T, object> keySelector,
                                                    Func<T, T, bool>? propertyComparer = null)
    {
        var oldDict = oldList.ToDictionary(keySelector);
        var newDict = newList.ToDictionary(keySelector);

        var added = newDict.Keys.Except(oldDict.Keys).Select(key => newDict[key]);
        var removed = oldDict.Keys.Except(newDict.Keys).Select(key => oldDict[key]);

        var unchanged = oldDict.Keys.Intersect(newDict.Keys)
                            .Where(key => propertyComparer == null || propertyComparer(oldDict[key], newDict[key]) == true)
                            .Select(key => oldDict[key]);

        var changed = oldDict.Keys.Intersect(newDict.Keys)
                            .Where(key => propertyComparer == null || propertyComparer(oldDict[key], newDict[key]) == false)
                            .Select (key => newDict[key]);

        

        return new CollectionComparisionResult<T>
        {
            Added = added,
            Removed = removed,
            Unchanged = unchanged,
            Changed = changed
        };
    }
}
