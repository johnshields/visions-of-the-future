using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// manages what is being built and allows buildings to be built

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

  void Awake ()
    {
        instance = this;
    }

    private Node selectedNode;

    public GameObject standardBuildingPrefab;
    public GameObject anotherBuildingPrefab;

    public NodeUI nodeUI;

    private GameObject buildingToBuild;

    public GameObject GetBuildingToBuild ()
    {
        return buildingToBuild;
    }

    public void SelectNode (Node node)
    {
        selectedNode = node;
        buildingToBuild = null; // disables ability to build buildings

        nodeUI.SetTarget(node);
    }


    public void SetBuildingToBuild (GameObject building) // public method that allows different buildings to be built
    {
        buildingToBuild = building; // builds whatever prefab has been passed in
        selectedNode = null; // disables ability to select nodes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
