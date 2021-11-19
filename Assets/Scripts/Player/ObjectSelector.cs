using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform playerCamera;

    [SerializeField]
    private Selectable currentSelection;

    [SerializeField]
    private float maxDistance = 1.5f;

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
            if (currentSelection != null && foundSelection == currentSelection)
            {
                currentSelection.OnDeselected.Invoke();
                currentSelection = null;
            }
            // Else swap selection
            else
            {
                currentSelection?.OnDeselected.Invoke();
                foundSelection?.OnSelected.Invoke();
                currentSelection = foundSelection;

                LogSelection();
            }
        }
    }

    private void LogSelection()
    {
        if (currentSelection != null)
        {
            SpyObject spyObject = currentSelection.GetComponent<SpyObject>();
            if (spyObject != null)
            {
                Debug.Log(spyObject.Data.name);
            }
        }
    }
}
