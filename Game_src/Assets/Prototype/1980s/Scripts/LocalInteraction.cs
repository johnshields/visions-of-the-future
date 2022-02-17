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

        screenPt = Camera.main.WorldToScreenPoint(transform.position);
        OffsetPos = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPt.z));
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPt.z));
    }
}
