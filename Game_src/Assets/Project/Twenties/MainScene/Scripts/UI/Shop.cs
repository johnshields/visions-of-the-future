using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public BuildingBlueprint transportBuilding; // creates a variable of the type BuildingBlueprint. Defined by the BuildingBlueprint attributes. Gameobject slot visible in inspector.
    public BuildingBlueprint leisureBuilding; // creates a variable of the type BuildingBlueprint - gameobject slot visible in inspector
    public BuildingBlueprint gardenBuilding;
    public BuildingBlueprint highRiseBuilding;
    public BuildingBlueprint steppedBuilding;
    public BuildingBlueprint apartmentBuilding;
    public BuildingBlueprint flatBuilding;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTransportBuilding() // communicates with the BuildManager to select the Standard Building button and then build a standard building. Called when the user clicks the Standard Building button.
    {
        Debug.Log("transport building selected");
        buildManager.SelectBuildingToBuild(transportBuilding); // tells the BuildManager to call SetBuildingToBuild, with the standardBuilding being defined as the building to be built. standardBuilding is the prefab placed in the inspector slot.
    }

    public void SelectCommercialBuilding() // communicates with the BuildManager to select the another Building button and then build a another building. Called when the user clicks the Another Building button.
    {
        Debug.Log("commerical building selected");
        buildManager.SelectBuildingToBuild(leisureBuilding); // ditto as command in SelectStandardBuilding
    }

    public void SelectGardenBuilding() // ditto as above
    {
        Debug.Log("garden building selected");
        buildManager.SelectBuildingToBuild(gardenBuilding);
    }

    public void SelectLeisureBuilding() // ditto as above
    {
    {
        Debug.Log("leisure building selected");
        buildManager.SelectBuildingToBuild(highRiseBuilding);
    }

    public void SelectSteppedBuilding() // ditto as above
    {
    {
        Debug.Log("stepped building selected");
        buildManager.SelectBuildingToBuild(steppedBuilding);
    }

    public void SelectApartmentBuilding() // ditto as above
    {
    {
        Debug.Log("apartment building selected");
        buildManager.SelectBuildingToBuild(apartmentBuilding);
    }

    public void SelectAnotherApartmentBuilding() // ditto as above
    {
    {
        Debug.Log("another apartment building selected");
        buildManager.SelectBuildingToBuild(flatBuilding);
    }


    





}
