using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _mOffset;
    private float _mZCoord;

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
}
