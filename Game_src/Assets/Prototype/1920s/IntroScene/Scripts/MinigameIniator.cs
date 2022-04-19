using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameIniator : MonoBehaviour
{
    public GameObject miniGameUI;

    public GameObject returnUI;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MiniGameUI"))
        {
            miniGameUI.SetActive(true);
        }
        
        else if (other.CompareTag("ReturnUI"))
        {
            returnUI.SetActive(true);
        }
    }
}
