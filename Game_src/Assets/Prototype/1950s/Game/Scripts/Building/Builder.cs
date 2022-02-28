using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject[] buildingObject;
    private int _selectedObject;
    public static int objectsInScene;
    private bool _limited;

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
        BobTheBuilder();
    }

    private void BobTheBuilder()
    {
        // Spawn object when right mouse is clicked.
        if (Input.GetMouseButtonDown(1) && objectsInScene < 24)
        {
            var mousePos = Input.mousePosition;
            mousePos.z = 5;
            var worldPos = Camera.main!.ScreenToWorldPoint(mousePos);
            Instantiate(buildingObject[_selectedObject], worldPos, Quaternion.identity);
            objectsInScene++;
            print("Added Object - Object Count: " + objectsInScene);
        }
        else if (objectsInScene == 24 && !_limited)
        {
            Debug.LogWarning("[WARN]: Too many objects in scene!");
            _limited = true;
        }
        else if (objectsInScene < 24)
        {
            _limited = false;
        }
    }
}