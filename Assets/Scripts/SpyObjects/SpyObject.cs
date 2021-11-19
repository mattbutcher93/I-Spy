using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyObject : MonoBehaviour
{
    public List<string> PossibleNames
    {
        get;
        private set;
    }

    [SerializeField]
    private SpyObjectData spyObjectData;

    private void Awake()
    {
        if (spyObjectData == null)
        {
            Debug.LogWarning(gameObject.name + ": Spy object without data!");
        }
        else if (spyObjectData.possibleNames == null || spyObjectData.possibleNames.Length == 0)
        {
            Debug.LogWarning(spyObjectData.name + ": Spy object data has no names!");
        }
        else
        {
            PossibleNames = new List<string>(spyObjectData.possibleNames);
        }
    }
}
