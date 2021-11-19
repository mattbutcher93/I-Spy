using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class ISpyController : MonoBehaviour
{
    private ISpy iSpy;
    private List<SpyObjectData> allSpyObjects;


    private void Awake()
    {
        allSpyObjects = GameObject.FindObjectsOfType<SpyObject>().Select(spyObject => spyObject.Data)
                                                                                     .Distinct()
                                                                                     .ToList();

        iSpy = new ISpy(allSpyObjects);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(iSpy.SpyRequest().name);
        }
    }
}
