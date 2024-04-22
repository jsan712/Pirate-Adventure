using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private Material _defaultMaterial;
    [SerializeField] private Material _hoveredMaterial;

    public string Caption;
    public float DisplayDuration;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMaterial = _meshRenderer.material;
    }

    public void HoverHighlight(bool trueFalse)
    {        
        if (trueFalse)
        {
            _meshRenderer.material = _hoveredMaterial;
        }
        else
        {
            _meshRenderer.material = _defaultMaterial;
        }
    }
}
