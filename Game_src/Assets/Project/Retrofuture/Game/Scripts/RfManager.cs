using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class RfManager : MonoBehaviour
{
    private GameObject _guide;
    
    private void Awake()
    {
        _guide = GameObject.FindGameObjectWithTag("Guide");
        _guide.GetComponent<AIPath>().enabled = false;
        StartCoroutine(Activate());
    }

    private IEnumerator Activate()
    {
        yield return new WaitForSeconds(2.5f);
        _guide.GetComponent<AIPath>().enabled = true;
    }
}
