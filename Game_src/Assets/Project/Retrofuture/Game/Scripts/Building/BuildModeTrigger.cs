using UnityEngine;

public class BuildModeTrigger : MonoBehaviour
{
    public GameObject[] buildingObjects;
    private bool _entered;
    public GameObject mainCam;
    public GameObject bunkerCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!_entered)
            {
                print("Build mode on.");
                buildingObjects[0].SetActive(true);
                buildingObjects[1].SetActive(true);
                bunkerCam.SetActive(true);
                mainCam.SetActive(false);
                _entered = true;
            }
            else
            {
                print("Build mode off.");
                buildingObjects[0].SetActive(false);
                buildingObjects[1].SetActive(false);
                bunkerCam.SetActive(false);
                mainCam.SetActive(true);
                _entered = false;
            }
        }
    }
}