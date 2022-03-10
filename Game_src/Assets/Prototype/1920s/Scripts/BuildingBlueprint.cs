using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // gameobject and cost will now be visible inside the inspector
public class BuildingBlueprint
{
    public GameObject prefab; // creates a public gameobject in the inspector
    public int cost; // creates a public integer value in the inspector
}
