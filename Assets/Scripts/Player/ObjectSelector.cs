using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform playerCamera;


    [SerializeField]
    private float maxDistance = 1.5f;

    public Selectable CurrentSelection
    {
        get;
        private set;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            RaycastHit hit;
            Selectable foundSelection = null;

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance, layerMask))
            {
                foundSelection = hit.transform.GetComponent<Selectable>();
            }

            // If selecting same object, then deselect
            if (CurrentSelection != null && foundSelection == CurrentSelection)
            {
                CurrentSelection.OnDeselected.Invoke();
                CurrentSelection = null;
            }
            // Else swap selection
            else
            {
                CurrentSelection?.OnDeselected.Invoke();
                foundSelection?.OnSelected.Invoke();
                CurrentSelection = foundSelection;

                LogSelection();
            }
        }
    }

    private void LogSelection()
    {
        if (CurrentSelection != null)
        {
            SpyObject spyObject = CurrentSelection.GetComponent<SpyObject>();
            if (spyObject != null)
            {
                Debug.Log(spyObject.Data.name);
            }
        }
    }
}
