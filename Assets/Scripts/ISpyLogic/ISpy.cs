using System.Collections.Generic;
using UnityEngine;

public class ISpy
{
    private List<SpyObjectData> allSpyObjects;

    private List<SpyObjectData> currentSpyObjectPool;
    private System.Random random;

    public ISpy(List<SpyObjectData> spyObjects)
    {
        if (spyObjects == null || spyObjects.Count == 0)
        {
            Debug.Log("Initialised with no spy objects!");
        }
        else
        {
            allSpyObjects = new List<SpyObjectData>(spyObjects);
            currentSpyObjectPool = new List<SpyObjectData>(spyObjects);
        }

        random = new System.Random();

        foreach (SpyObjectData data in allSpyObjects) Debug.Log(data.name);
    }

    // Select a random object and remove it from the pool
    // Returns null if no spy objects available
    // Reset the pool if no spy objects left
    public SpyObjectData SpyRequest()
    {
        if (allSpyObjects == null || allSpyObjects.Count == 0)
        {
            return null;
        }

        SpyObjectData randomObject = null;

        if (currentSpyObjectPool.Count == 0)
        {
            Reset();
        }

        randomObject = currentSpyObjectPool[random.Next(currentSpyObjectPool.Count)];
        currentSpyObjectPool.Remove(randomObject);

        return randomObject;
    }

    // Reset object pool to contain all original objects
    public void Reset()
    {
        currentSpyObjectPool = new List<SpyObjectData>(allSpyObjects);
    }
}
