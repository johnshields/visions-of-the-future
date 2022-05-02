using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour

// keeps track of whether something is built on a particular node, handles user inputs, checks whether the player has selected the node and allows buildings to be built

{
    BuildManager buildManager;
    ScoreManager scoreManager;
    AudioManager audioManager;
    CityIntensityAudioManager intensityAudioManager;    
    

    public Color hoverColour; // creates a colour in the inspector, which I can then populate with the intended colour.
    public Color startColour; // creates a colour in the inspector, which I can then populate with the intended colour.

    public Vector3 positionOffset;

    public GameObject hintUI;
    public GameObject shopUI;

    private int hintUICounter;

    private GameObject building; // stores whether a building has been built on a particular node. Building is automatically set to null, allowing players to build on top of the node.

   
    private Renderer rend;    

    private Animator myAnim;


    string nodeTag;
    string buildingTag;   



    void Start()
    {
        buildManager = BuildManager.instance;
        scoreManager = ScoreManager.instance;
        audioManager = AudioManager.instance;
        intensityAudioManager = CityIntensityAudioManager.instance;
        

        rend = GetComponent<Renderer>(); // calls the renderer of a selected node. Caching this information within the start method makes the system more performant

        nodeTag = this.tag; // sets nodeTag to the tag assigned to the gameobject the script is attached to              

        
    }


    // Controls hover colour changes

    void OnMouseEnter() // called everytime the mouse enters the collider of the object
    {
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



        if (building != null) // if the building is not equal to null, e.g. a building has been built on top of the node
        {
            buildManager.SelectNode(this); // passes in the selected node by the player into the SelectNode function in the BuildManager script.
            return;
        }

        if (!buildManager.CanBuild)
            return;            


        BuildBuilding(buildManager.GetBuildingToBuild());

        buildingTag = building.tag; // assigns the tag of the building built on the node as buildingTag

        StartCoroutine(AddScoreChecker()); // calls the AddScoreChecker method

        audioManager.BuildSoundPlay();
        intensityAudioManager.CityIntensityIncreaser();
          
    }
    


    void BuildBuilding(BuildingBlueprint blueprint) // builds the buildings ontop of the selected node
    {
        // GameObject _placeHolder = (GameObject)Instantiate(placeHolder, transform.position + positionOffset, transform.rotation);
        // Destroy(_placeholder, 10f);

        GameObject _building = (GameObject)Instantiate(blueprint.prefab, transform.position + positionOffset, transform.rotation); // instantiates the building at the position (plus an offset) and rotation of the selected node
        building = _building;
    }



    // NodeUI functionality


    public IEnumerator DestroyBuilding() // destorys the building
    {
        myAnim = building.GetComponent<Animator>(); // assigns myAnim as the animator component of the building built on the node
        myAnim.SetBool("Destroy", true); // sets the bool in the animator controllor attached to the building to true

        DecreaseScoreChecker(); // calls the DecreaseScoreChecker method

        audioManager.DestroySoundPlay();
        intensityAudioManager.CityIntensityDecreaser();

        yield return new WaitForSecondsRealtime(5f);
        myAnim.SetBool("Destroy", false);
        Destroy(building); // destroys the building after 2.5 seconds have passed - 2.5 seconds is the amount of time the destory animation takes.
        building = null; // sets building back to null, allowing another building to be built on top of the node        
    }

    

    public void RotateBuilding() // rotates the building built on the node
    {
        building.transform.Rotate(0, 90, 0); // digs down to the buildings transform component and turns it 90 degrees on the y axis
    }




    // Score methods

    public IEnumerator AddScoreChecker() // checks whether the building built on the node has the same tag as the node, executing different commands depending whether they match
    {
        yield return new WaitForSecondsRealtime(5f);

        if (buildingTag == nodeTag) // if buildingTag is equal to the nodeTag
        {
            scoreManager.AddScore(); // calls the AddScore method in ScoreManager script
        }        
        else if(hintUICounter < 2)        
        {
            Debug.Log("NoPoints");
            hintUI.SetActive(true);
            shopUI.SetActive(false);
            hintUICounter ++;
            
            
        }

        else if (hintUICounter >= 2)
        {
            Debug.Log("you're an idiot");
        }
    }

    public void DecreaseScoreChecker() // checks whether the building destroyed on the node has the same tag as the node, executing different commands depending whether they match
    {
        if (buildingTag == nodeTag) // if the building tag is equal to the nodeTag
        {
            scoreManager.DecreaseScore(); // calls the DecreaseScore method in the scoreManager script
        } 
        
        else        
        {
            Debug.Log("NoPointsMinus");
            return;
        }
    }

}


