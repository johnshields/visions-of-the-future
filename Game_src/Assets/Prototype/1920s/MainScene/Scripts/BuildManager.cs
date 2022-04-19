using UnityEngine;

public class BuildManager : MonoBehaviour // manages the building of buildings
{
    // singleton pattern

    public static BuildManager instance; // creates a reference to the BuildManager script, storing the script inside of itself.

    void Awake ()
    {
        instance = this; // the BuildManager script, referenced by 'this' is passed into the instance variable. This makes the BuildManager script, and the methods inside it, accesible from other scripts.
    }


    // Building Methods

    private BuildingBlueprint buildingToBuild;

    private Node selectedNode;

    public NodeUI nodeUI;

    public bool CanBuild {get {return buildingToBuild != null;}} // property. CanBuild checks whether turret to build is not equal to null. Returns true if is not equal. Returns false if it is equal.

    public GameObject builtBuilding;


    
    
    public void SelectBuildingToBuild(BuildingBlueprint building) // Function that is called when the SelectStandardBuilding and SelectAnotherBuilding are executed. Selects what building is to be built depending on what building is passed in. The building passed in is defined in SelectStandardBuilding and SelectAnotherBuilding in the Shop script.
    {      

        buildingToBuild = building; // sets buildingToBuild as the blueprint that is passed in from SelectStandardBuilding and SelectAnotherBuilding

        
       
       //  DoCorrectOrNotCorrectStuff()      
        
        selectedNode = null; // by setting selectedNode to null, players cannot have another node selected whilst the select a node to build on. Intended to avoid confusion from the players perspective.
        
        DeselectNode(); // calls the DeselectNode function
    }

    

    public BuildingBlueprint GetBuildingToBuild()
    {
        return buildingToBuild;
        
    }




    public void SelectNode(Node node) // Allows nodes to be selected and keeps track of what node is selected
    {       
        
        if (selectedNode == node) // if the selected node is the same as the node already selected
        {
            DeselectNode(); // node is deselected
            return;
        }

        selectedNode = node; // sets selectedNode as the node that is passed in from... 
        
        buildingToBuild = null; // By setting buildingToBuild to null, players cannot have a node selected and then build on a node. Intended to avoid confusion from the players perspective.

        nodeUI.SetTarget(node);

        
    }

    public void DeselectNode() // deselects nodes
    {
        selectedNode = null; // sets the selected node to null, deselecting the currently selected node.
        nodeUI.UiReset(); // calls the UiReset in the NodeUI script
    }

    
    public void SetBuiltBuilding(GameObject selectedBuilding)
    {
        builtBuilding = selectedBuilding;
    }
    
}