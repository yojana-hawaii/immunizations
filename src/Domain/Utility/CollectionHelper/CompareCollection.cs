namespace Domain.Utility.CollectionHelper;

public static class CompareCollection<T>
{

    public static CollectionComparisionResult<T> CompareLists(IEnumerable<T> oldList,IEnumerable<T> newList,Func<T, object> keySelector,Func<T, T, bool>? propertyComparer = null)
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

    //web.archive.org codeducky.org > URL in github issues
    public static bool CollectionEquals(IEnumerable<T> currentObject, IEnumerable<T> newObject, IEqualityComparer<T> comparer)
    {
        //short circuit >  if the number of items in list > list of objects is not equal
        int currentObjectCount, newObjectCount;
        if (TryFastCount(currentObject, out currentObjectCount)
            && TryFastCount(newObject, out newObjectCount)
            && currentObjectCount != newObjectCount
            )
        {
            return false;
        }

        //Optimistic approach > for faster performance > assume they are in sequence, which they should be unless something is deleted
        if (AssumingSequenceEquality(currentObject, newObject, comparer))
        {
            return true;
        }

        //if sequence comparison fails > brute force loop through two list of object for O^2
        return BruteForceEquality(currentObject, newObject, comparer);
    }
    private static bool BruteForceEquality(IEnumerable<T> currentObjectList, IEnumerable<T> newObjectList, IEqualityComparer<T> comparer)
    {
        var isEqual = true;

        foreach (var current in currentObjectList)
        {
            foreach (var newObject in newObjectList)
            {
                if (!comparer.Equals(current, newObject))
                {
                    isEqual = false;
                    break;
                }
            }
        }

        return isEqual;
    }
    private static bool AssumingSequenceEquality(IEnumerable<T> currentObject, IEnumerable<T> newObject, IEqualityComparer<T> comparer)
    {
        var isEqual = true;

        //compare two object in sequence if not equal found then return false.
        using (var currentEnumerator = currentObject.GetEnumerator())
        using (var newEnumerator = newObject.GetEnumerator())
        {
            while (true)
            {
                var currentFiinished = currentEnumerator.MoveNext();
                var newFiished = newEnumerator.MoveNext();

                if (currentFiinished) { return newFiished; }
                if (newFiished) { return false; }

                if (!comparer.Equals(currentEnumerator.Current, newEnumerator.Current))
                {
                    isEqual = false;
                    break;
                }
            }
        }

        return isEqual;

    }
    private static bool TryFastCount(IEnumerable<T> sequence, out int count)
    {
        // IEnumberable does  not have count property but dont need additional method of IList
        ICollection<T> collection = sequence.ToList();
        if (collection != null)
        {
            count = collection.Count;
            return true;
        }
        count = -1;
        return false;
    }

}
