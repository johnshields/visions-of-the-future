using UnityEngine;

namespace Building
{
    public class DragObject : MonoBehaviour
    {
        private Vector3 _mOffset;
        private float _mZCoord;
    
        private void OnMouseDown()
        {
            _mZCoord = Camera.main!.WorldToScreenPoint(gameObject.transform.position).z;
            _mOffset = gameObject.transform.position - GetMouseWorldPos();
            print("Object clicked");
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
            {
                Destroy(gameObject);
                print("Object destroyed");
            }
        }
    }
}
