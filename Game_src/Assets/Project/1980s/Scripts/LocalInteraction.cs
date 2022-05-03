using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalInteraction : MonoBehaviour
{
    private Vector3 screenPt;
    private Vector3 OffsetPos;

    private void OnMouseDown()
    {
        Debug.Log(transform.name + " clicked");

        //Sets up simple mouse object interacion when player clicks on object with this script
        screenPt = Camera.main.WorldToScreenPoint(transform.position);
        //Sets the offset position for the target object so that the object stays at the same distance wawy from the player when picked up
        OffsetPos = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPt.z));
    }

    private void OnMouseDrag()
    {
        //Transforms the object position to the pointer location
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPt.z));
    }
}
