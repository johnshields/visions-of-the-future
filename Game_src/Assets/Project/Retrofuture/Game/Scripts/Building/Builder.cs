using System.Collections;
using UnityEngine;

namespace Building
{
    public class Builder : MonoBehaviour
    {
        public GameObject[] buildingObject;
        private int _selectedObject;
        public int objectPos;
        public static int objectsPlaced;
        public AudioClip clip;

        public void Selector(int num)
        {
            // Inventory selector.
            switch (num)
            {
                case 0:
                    print("selected: " + _selectedObject);
                    _selectedObject = 0;
                    break;
                case 1:
                    print("selected: " + _selectedObject);
                    _selectedObject = 1;
                    break;
                case 2:
                    print("selected: " + _selectedObject);
                    _selectedObject = 2;
                    break;
                case 3:
                    print("selected: " + _selectedObject);
                    _selectedObject = 3;
                    break;
                case 4:
                    print("selected: " + _selectedObject);
                    _selectedObject = 4;
                    break;
                case 5:
                    print("selected: " + _selectedObject);
                    _selectedObject = 5;
                    break;
                case 6:
                    print("selected: " + _selectedObject);
                    _selectedObject = 6;
                    break;
                case 7:
                    print("selected: " + _selectedObject);
                    _selectedObject = 7;
                    break;
                case 8:
                    print("selected: " + _selectedObject);
                    _selectedObject = 8;
                    break;
                case 9:
                    print("selected: " + _selectedObject);
                    _selectedObject = 9;
                    break;
            }
        }

        private void Update()
        {
            // Spawn object when right mouse is clicked - (capped at 15).
            if (Input.GetMouseButtonDown(1) && objectsPlaced < 15)
            {
                var mousePos = Input.mousePosition;
                mousePos.z = objectPos;
                var worldPos = Camera.main!.ScreenToWorldPoint(mousePos);
                Instantiate(buildingObject[_selectedObject], worldPos, Quaternion.identity);
                objectsPlaced++;
                print("Objects in Scene: " + objectsPlaced);
                StartCoroutine(PlayClip());
            }
        }

        private IEnumerator PlayClip()
        {
            yield return new WaitForSeconds(0.5f);
            AudioSource.PlayClipAtPoint(clip, Camera.main!.transform.position, 0.1f);
        }
    }
}
