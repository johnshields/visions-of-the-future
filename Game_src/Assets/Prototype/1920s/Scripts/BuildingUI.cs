using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public BuildingBlueprint standardBuilding; // defines what standardBuilding is
    public BuildingBlueprint anotherBuilding; // defines what anotherBuilding is


    BuildManager buildManager;


    void Start()
    {
        buildManager = BuildManager.instance;
    }

   public void SelectStandardBuilding ()
   {
       Debug.Log("Standard Building Selected");
       buildManager.SelectBuildingToBuild(standardBuilding); // calls a method on the buildmanager called SellectBuildingToBuild and passes in the specific building to be built
   }

   public void SelectAnotherBuilding ()
   {
       Debug.Log("Another Building Selected");
       buildManager.SelectBuildingToBuild(anotherBuilding);
   }
}
