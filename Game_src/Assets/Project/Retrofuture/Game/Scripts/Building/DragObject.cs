using System;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _mOffset;
    private float _mZCoord;
    private bool _toggleState;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        _mZCoord = Camera.main!.WorldToScreenPoint(gameObject.transform.position).z;
        _mOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        var mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoord;
        
        return Camera.main!.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _mOffset;
        
        if (Input.GetKey(KeyCode.Z) && Input.GetMouseButton(0))
            Destroy(gameObject);
    }
    
    private void OnMouseOver()
    {
        ToggleState();
        
        if (_renderer) // check if the renderer is null
        {
            _renderer.material.color = _toggleState ? Color.white : Color.blue;
        }
        else Debug.LogWarning("Objects does not have a renderer");
    }
    
    private void ToggleState()
    {
        _toggleState = !_toggleState;
    }
}
