using Pathfinding;
using UnityEngine;
using Guide;

namespace Building
{
    public class BuildModeTrigger : MonoBehaviour
    {
        public GameObject[] buildingObjects;
        private bool _entered;
        public GameObject guide;
        public static bool build;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!_entered)
                {
                    print("Build mode on.");
                    buildingObjects[0].SetActive(true);
                    buildingObjects[1].SetActive(true);
                    DisableGuide(false);
                    build = true;
                    _entered = true;
                }
                else
                {
                    print("Build mode off.");
                    buildingObjects[0].SetActive(false);
                    buildingObjects[1].SetActive(false);
                    DisableGuide(true);
                    build = false;
                    _entered = false;
                }
            }
        }

        private void DisableGuide(bool active)
        {
            guide.GetComponent<AIPath>().enabled = active;
            guide.GetComponent<Seeker>().enabled = active;
        }
    }
}