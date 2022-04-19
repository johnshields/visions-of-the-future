using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour

// keeps track of whether something is built on a particular node, handles user inputs, checks whether the player has selected the node and allows buildings to be built

{
    public Color hoverColour; // creates a colour in the inspector, which I can then populate with the intended colour.
    public Color startColour; // creates a colour in the inspector, which I can then populate with the intended colour.

    public Vector3 positionOffset;

    public GameObject building; // stores whether a building has been built on a particular node. Building is automatically set to null, allowing players to build on top of the node.
   
    private Renderer rend;

    BuildManager buildManager;

    private Animator myAnim;

    public GameObject oldBuilding;



    void Start()
    {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>(); // calls the renderer of a selected node. Caching this information within the start method makes the system more performant                

        BuildOldCityBuilding();
    }


    // Controls hover colour changes

    void OnMouseEnter() // called everytime the mouse enters the collider of the object
    {
        // if (buildManager.GetBuildingToBuild() == null)
        // return;

        // if (EventSystem.current.IsPointerOverGameObject()) // checks whether the mouse is pointing over a given gameobject.
        // return; // if the pointer is over a given gameobject, then the script does not exectue the below command.

        if (!buildManager.CanBuild)
        {
            return;
        }

        rend.material.color = hoverColour; // gets the material of the selected node and changes it to hoverColour
    }

    void OnMouseExit() // called everytime the mouse exits the collider of the object
    {
        rend.material.color = startColour; // gets the material of the selected node and changes it to startColour
    }


    // Building Methods

    void OnMouseDown() // called when the mouse button is pressed down
    {
        // if (buildManager.GetBuildingToBuild() == null)
        // return;

        // if (EventSystem.current.IsPointerOverGameObject()) // checks whether the mouse is pointing over a given gameobject.
        // return; // if the pointer is over a given gameobject, then the script does not exectue the below command.



        if (building != null) // if the building is not equal to null, e.g. a building has been built on top of the node
        {
            buildManager.SelectNode(this); // passes in the selected node by the player into the SelectNode function in the BuildManager script.
            return;
        }

        if (!buildManager.CanBuild)
            return;            


        BuildBuilding(buildManager.GetBuildingToBuild());

        // string buildingTag = building.tag;
        //bool isCorrect = CheckIfCorrect(buildingTag, this);  

        string buildingTag = building.tag;
        string nodeTag = this.tag;
        int score = 0;

        if (buildingTag == nodeTag){
            Debug.Log("Call Correct Function");
            score++;
        } else {
            Debug.Log("call Wrong Fucntion");
            score--;
        }
        print("SCORE: " + score);
          
    }

    // public static bool CheckIfCorrect(string tag, Node node) 
    // {    
        

    //     if (tag == node.tag) 
    //     {
        
    //         return true; // calls function here
    //     }
    //     else
    //         return false;
    // }






    // public void CreateBuildingPlaceHolder() // creates the placeholder building and particle system on the selected node
    // {
    // GameObject effect = (GameObject)Instantiate(buildEffect, transform.position + positionOffset, transform.rotation); // instantiates the buildEffect at the selected node's position plus an offset
    // Destroy(effect, 5f); // destroys the build effect after 5 seconds

    // GameObject holder = (GameObject)Instantiate(placeHolder, transform.position + positionOffset, transform.rotation); // instantiates the buildEffect at the selected node's position plus an offset
    // Destroy(holder, 5f); // destroys the placeholder prefab after 5 seconds
    // }

    void BuildBuilding(BuildingBlueprint blueprint) // builds the buildings ontop of the selected node
    {
        // GameObject _placeHolder = (GameObject)Instantiate(placeHolder, transform.position + positionOffset, transform.rotation);
        // Destroy(_placeholder, 10f);

        GameObject _building = (GameObject)Instantiate(blueprint.prefab, transform.position + positionOffset, transform.rotation); // instantiates the building at the position (plus an offset) and rotation of the selected node
        building = _building;
    }


    public IEnumerator DestroyBuilding()
    {
        myAnim = building.GetComponent<Animator>();
        myAnim.SetBool("Destroy", true);

        yield return new WaitForSecondsRealtime(2.5f);
        myAnim.SetBool("Destroy", false);
        Destroy(building);
        building = null;
    }

    // public void DestroyBuilding() // destroys the building built on the selected node
    // {
    // Destroy(building); // destroys the building built on the node
    // building = null; // sets the buildingBlueprint to null, allowing another building to be built on that node
    // }

    public void RotateBuilding() // rotates the building built on the node
    {
        building.transform.Rotate(0, 90, 0); // digs down to the buildings transform component and turns it 90 degrees on the z axis
    }


    public void BuildOldCityBuilding() // instantiates the old city seen at the start of the game
    {
        if (oldBuilding == null)
        {
            return;
        }

        GameObject _oldBuilding = (GameObject)Instantiate(oldBuilding, transform.position + positionOffset, transform.rotation); // instantiates the building at the position (plus an offset) and rotation of the selected node
        building = _oldBuilding; // the temporary gameobject _oldBuilding is passed into the building variable into the inspector, allowing it to be selected, roated and deleted.

        // oldBuilding = buildManager.builtBuilding;
    }

    // public void PassinBuilding()
    // {
        // buildManager.SetBuiltBuilding(building);
    // }

}


