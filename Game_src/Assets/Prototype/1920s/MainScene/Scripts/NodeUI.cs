using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject _ui;

    private Node target;

    public void SetTarget(Node _target) // sets the target for where the NodeUI gameobject will appear
    {
        target = _target; // sets target to _target, which is whatever node is passed in the SelectNode function in the BuildManager script
        transform.position = target.transform.position; // changes the position of the NodeUI to the postion of the target node
        ui.SetActive(true); // sets the gameobject passed into the UI slot in the inspector to active when the player clicks on the built node, making it visible.
        _ui.SetActive(false);
    }

    public void UiReset() // gives the player the option to hide the NodeUI - having the NodeUI visible at all times could get annoying
    {
        ui.SetActive(false); // sets the gameobject passed into the UI slot in the inspector to false as default, hiding it.
        _ui.SetActive(true);
    }

    public void Rotate () // calls the RotateBuilding function in the Node Script
    {
        target.RotateBuilding();
        BuildManager.instance.DeselectNode(); // deselects the NodeUI once the building has been rotated. Thought this would be better from a usability pov.
    }

    public void Destory()
    {
        StartCoroutine(target.DestroyBuilding()); // starts the coroutine for DestroyBuilding
        BuildManager.instance.DeselectNode();
        //target.DestroyBuilding();
    }

}
