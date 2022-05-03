using UnityEngine;

/*
 * DragObject
 * Script to Drag objects once they are placed by Builder. Plus deletion of objects.
 */
namespace Building
{
    public class DragObject : MonoBehaviour
    {
        private Vector3 _mOffset;
        private float _mZCoord;

        private void OnMouseDown()
        {
            // When object is clicked allow to drag it.
            _mZCoord = Camera.main!.WorldToScreenPoint(gameObject.transform.position).z;
            _mOffset = gameObject.transform.position - GetMouseWorldPos();
            print("Object clicked");
        }

        // Get Mouse position in Camera View
        private Vector3 GetMouseWorldPos()
        {
            var mousePoint = Input.mousePosition;
            mousePoint.z = _mZCoord;

            return Camera.main!.ScreenToWorldPoint(mousePoint);
        }

        // For deleting Dragged Object.
        private void OnMouseDrag()
        {
            transform.position = GetMouseWorldPos() + _mOffset;

            if (Input.GetKey(KeyCode.R) && Input.GetMouseButton(0))
            {
                Destroy(gameObject);
                print("Object destroyed");
                // Update objectsPlaced number.
                Builder.objectsPlaced--;
            }
        }
    }
}
