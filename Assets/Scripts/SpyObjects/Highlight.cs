using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    [SerializeField]
    private Color highlightColor = Color.green;

    [SerializeField]
    private MeshRenderer meshRenderer;

    private Color baseColor;

    private void Awake()
    {
        if (meshRenderer != null)
        {
            baseColor = meshRenderer.material.color;
        }
    }

    public void HighlightObject()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.SetColor("_Color", highlightColor);
        }
    }

    public void UnhighlightObject()
    {
        if (meshRenderer != null)
        {
            meshRenderer.material.SetColor("_Color", baseColor);
        }
    }
}
