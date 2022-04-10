using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV_GuideFollower : MonoBehaviour
{
    public GameObject player;
    public GameObject guide;
    public float targetDistance;
    public float allowedDistance = 5;
    public float followSpeed;
    public RaycastHit shot;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.LookAt(player.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection((Vector3.forward)), out shot));
        {
            targetDistance = shot.distance;
            if (targetDistance >= allowedDistance)
            {
                followSpeed = 0.5f;
                //guide.GetComponent<Animator>().Play("Flying");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed);
            }
            else
            {
                followSpeed = 0;
                //guide.GetComponent<Animator>().Play("Idle");
            }
        }
    }
}
