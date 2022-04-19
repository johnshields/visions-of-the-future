using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportNode : MonoBehaviour
{

    BuildManager buildManager;


    public void Awake()
    {
        buildManager = BuildManager.instance;
    }

    public void TransportNodePopUp()
    {
        if (buildManager.builtBuilding == null)
        {
            return;
        }

        else if (buildManager.builtBuilding = GameObject.FindWithTag("OtherBuilding"))
        {
            Debug.Log("OtherBuilding Built");
        }

        else if (buildManager.builtBuilding = GameObject.FindWithTag("TransportBuilding"))
        {
            Debug.Log("TransportBuilding Built");
        }     
    }    
}
