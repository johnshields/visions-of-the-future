using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * Builder
 * Script to control the Builder Inventory - switches _selectedObjects.
 */
namespace Building
{
    public class Builder : MonoBehaviour
    {
        public GameObject[] buildingObject;
        public GameObject objectCounter;
        private int _selectedObject;
        public int objectPos;
        public static int objectsPlaced;
        public AudioClip clip, tv, computer, bar;

        // For switching _selectedObject depending on the num.
        public void Selector(int num)
        {
            // Inventory selector.
            switch (num)
            {
                case 0:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 0;
                    break;
                case 1:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 1;
                    break;
                case 2:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 2;
                    break;
                case 3:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 3;
                    break;
                case 4:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 4;
                    break;
                case 5:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 5;
                    break;
                case 6:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 6;
                    break;
                case 7:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 7;
                    break;
                case 8:
                    print("selected: " + buildingObject[_selectedObject].tag);
                    _selectedObject = 8;
                    break;
                case 9:
                    print("selected: " + buildingObject[_selectedObject].tag);
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
                // Place Object at Mouse position in Camera view.
                var worldPos = Camera.main!.ScreenToWorldPoint(mousePos);
                Instantiate(buildingObject[_selectedObject], worldPos, Quaternion.identity);
                // update object number and play sound.
                objectsPlaced++;
                StartCoroutine(PlayClip());
            }
        }
        
        // Update GUI objectCounter to let player know how many objects are in scene.
        private void OnGUI()
        {
            var objectsUI = objectCounter.GetComponent<Text>();
            if (objectsPlaced == 15)
                objectsUI.text = "MAX";
            else
                objectsUI.text = objectsPlaced.ToString();;
        }

        // IEnumerator to play sound clip according to the _selectedObject.
        private IEnumerator PlayClip()
        {
            yield return new WaitForSeconds(0.5f);
            switch (_selectedObject)
            {
                case 1:
                    AudioSource.PlayClipAtPoint(tv, Camera.main!.transform.position, 0.1f);
                    break;
                case 4:
                    AudioSource.PlayClipAtPoint(computer, Camera.main!.transform.position, 0.1f);
                    break;
                case 6:
                    AudioSource.PlayClipAtPoint(bar, Camera.main!.transform.position, 0.1f);
                    break;
                default:
                    AudioSource.PlayClipAtPoint(clip, Camera.main!.transform.position, 0.1f);
                    break;
            }
        }
    }
}
