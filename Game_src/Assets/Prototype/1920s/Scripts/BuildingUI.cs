using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    BuildManager buildManager;


    void Start()
    {
        buildManager = BuildManager.instance;
    }

   public void GetStandardBuilding ()
   {
       Debug.Log("Standard Building Selected");
       buildManager.SetBuildingToBuild(buildManager.standardBuildingPrefab);
   }

   public void GetAnotherBuilding ()
   {
       Debug.Log("Another Building Selected");
       buildManager.SetBuildingToBuild(buildManager.anotherBuildingPrefab);
   }
}
