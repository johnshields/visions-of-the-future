using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GuidePathfinding : MonoBehaviour
{
    public GameObject targetGameObject;
    public float speed;
    //public float distanceToWaypoint;
    //public float nextWayPointDistance;
    //private int currentWaypoint = 0;

    private Transform target;
    private CharacterController controller;

    Path path;
    Seeker seeker;

    public bool pathPossible = true;
    //private bool reachedEndOfPath;

    //private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        targetGameObject = GameObject.FindGameObjectWithTag("Player1980");
        target = targetGameObject.transform;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        CheckPath();
    }

    public void CheckPath()
    {
        GraphNode node1 = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        GraphNode node2 = AstarPath.active.GetNearest(target.position, NNConstraint.Default).node;

        if (PathUtilities.IsPathPossible(node1, node2))
        {
            pathPossible = true;
            return;
        }
        else {
            pathPossible = false;
        }
    }

    void UpdatePath() 
    {
        if (seeker.IsDone()) {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p) 
    {
        if (!p.error) {
            path = p;
            //currentWaypoint = 0;
        }
    }

/*    void FixedUpdate()
    {
        if (path == null) {
            return;
        }

        if (currentWaypoint <= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else {
            reachedEndOfPath = false;
        }


        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        Vector3 velocity = dir * speed;

        controller.SimpleMove(velocity);

        if (distance < nextWayPointDistance) {
            currentWaypoint++;
        }
   }*/
}
