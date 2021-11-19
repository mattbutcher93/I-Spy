using System.Collections.Generic;
using System;

public class ISpy
{
    private List<SpyObjectData> allSpyObjects;

    private List<SpyObjectData> currentSpyObjectPool;
    private Random random;

    public ISpy(List<SpyObjectData> spyObjects)
    {
        allSpyObjects = new List<SpyObjectData>(spyObjects);
        currentSpyObjectPool = new List<SpyObjectData>(spyObjects);
        random = new Random();
    }

    // Select a random object and remove it from the pool
    // Returns null if no objects left
    public SpyObjectData SpyRequest()
    {
        SpyObjectData randomObject = null;

        if (currentSpyObjectPool.Count > 0)
        {
            randomObject = currentSpyObjectPool[random.Next(currentSpyObjectPool.Count)];
            currentSpyObjectPool.Remove(randomObject);
        }
        return randomObject;
    }

    // Reset object pool to contain all original objects
    public void Reset()
    {
        currentSpyObjectPool = new List<SpyObjectData>(allSpyObjects);
    }
}
