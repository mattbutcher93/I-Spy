using UnityEngine;

public class SpyObject : MonoBehaviour
{
    public SpyObjectData Data
    {
        get { return data; }
    }
    [SerializeField]
    private SpyObjectData data;

    private void Awake()
    {
        if (data == null)
        {
            Debug.LogWarning(gameObject.name + ": Spy object without data!");
        }
    }
}
