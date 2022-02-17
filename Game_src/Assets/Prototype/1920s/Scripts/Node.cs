using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour

// keeps track of what is built on each node and handles user inputs

{

    public Vector3 positionOffset;

    public Color hoverColor;

    private Renderer rend;

    private Color startColor;

    private GameObject building;

    BuildManager buildManager;

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    void OnMouseDown () // called when the mouse is clicked
    {
        if (EventSystem.current.IsPointerOverGameObject()) // Stops the building being built if it is beneath the UI
            return;

        if (buildManager.GetBuildingToBuild() == null)
            return;

        if (building != null) // if a building has already been built on the node
        {
            buildManager.SelectNode(this);
            return;
        }

        GameObject buildingToBuild = buildManager.GetBuildingToBuild(); // calls BuildManager and builds building
        building = (GameObject)Instantiate(buildingToBuild, transform.position + positionOffset, transform.rotation); // builds building at the exact node position, with the offset
    }


    void OnMouseEnter () // is called once everytime mouse hovers over collider
    {
        if (EventSystem.current.IsPointerOverGameObject()) // Stops the tile changing colour if it is beneath the UI
            return;

        if (buildManager.GetBuildingToBuild() == null)
            return;
            
        rend.material.color = hoverColor; // digs down to objects material and changes it to hoverColor when mouse is over collider
    }

    void OnMouseExit () // is called when the mouse exits the collider
    {
        rend.material.color = startColor; // changes the material of the node back to its original color
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); // gets the renderer when the scene is initialised and caches it, rather than calling it each time OnMouseEnter is activated
        startColor = rend.material.color; // stores the original color of each node

        buildManager = BuildManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
