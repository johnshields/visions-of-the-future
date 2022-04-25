using UnityEngine;

namespace Building
{
    public class Builder : MonoBehaviour
    {
        public GameObject[] buildingObject;
        private int _selectedObject;
        public int objectPos;
        private int _objectsPlaced = 0;

        public void Selector(int num)
        {
            // Inventory selector.
            switch (num)
            {
                case 0:
                    print("0 selected");
                    _selectedObject = 0;
                    break;
                case 1:
                    print("1 selected");
                    _selectedObject = 1;
                    break;
                case 2:
                    print("2 selected");
                    _selectedObject = 2;
                    break;
                case 3:
                    print("3 selected");
                    _selectedObject = 3;
                    break;
            }
        }

        private void Update()
        {
            // Spawn object when right mouse is clicked - (capped at 15).
            if (Input.GetMouseButtonDown(1) && _objectsPlaced < 15)
            {
                var mousePos = Input.mousePosition;
                mousePos.z = objectPos;
                var worldPos = Camera.main!.ScreenToWorldPoint(mousePos);
                Instantiate(buildingObject[_selectedObject], worldPos, Quaternion.identity);
                _objectsPlaced++;
                print("Objects placed: " + _objectsPlaced);
            }
        }
    }
}
