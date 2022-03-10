using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages what is being built and allows buildings to be built

public class BuildManager : MonoBehaviour
{
    

  void Awake ()
    {
        instance = this;
    }

   

    public GameObject standardBuildingPrefab;
    public GameObject anotherBuildingPrefab;
    public GameObject buildEffect;

    public NodeUI nodeUI;

    private BuildingBlueprint buildingToBuild;
    private Node selectedBuilding;

    public static BuildManager instance;


    public bool CanBuild { get { return buildingToBuild != null;}} // property that checks to see if buldingToBuild is null and returns the results. Null = can't build.
    
    public void SelectBuildingToBuild(BuildingBlueprint building)
    {
        buildingToBuild = building;
        selectedBuilding = null;
    }

    public void SelectBuilding (Node node)
    {
        selectedBuilding = node;
        buildingToBuild = null; // when a building is selected, this means the node cannot be selected as well

        nodeUI.SetTarget(node);
    }

    public void BuildBuildingOn(Node node)
    {
        GameObject building = (GameObject)Instantiate(buildingToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.building = building;
    }
}
