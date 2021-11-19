using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform playerCamera;

    [SerializeField]
    private Selectable currentSelection;

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            RaycastHit hit;
            bool selectionChanged = false;
            Selectable foundSelection = null;

            // Find a selection and check if different from current selection
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 1f, layerMask))
            {
                foundSelection = hit.transform.GetComponent<Selectable>();

                if (foundSelection != currentSelection)
                {
                    selectionChanged = true;
                }
            }

            // If an object cannot be found and there is a selection
            if (foundSelection == null && currentSelection != null)
            {
                selectionChanged = true;
            }

            if (selectionChanged)
            {
                currentSelection?.OnDeselected.Invoke();
                foundSelection?.OnSelected.Invoke();
                currentSelection = foundSelection;
            }
        }
    }
}
