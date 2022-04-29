using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GuidePathfinding : MonoBehaviour
{
    public GameObject targetGameObject;
    public float speed;

    private Transform target;
    private CharacterController controller;

    Path path;
    Seeker seeker;

    public bool pathPossible = true;

    void Start()
    {
        //Sets up necessary components to follow
        seeker = GetComponent<Seeker>();
        targetGameObject = GameObject.FindGameObjectWithTag("Player1980");
        target = targetGameObject.transform;


        InvokeRepeating("UpdatePath", 0f, 0.5f);
        CheckPath();
    }

    //Checks if the chosen path is possible between two points
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

    //Checks if target has been reached and starts new path
    void UpdatePath() 
    {
        if (seeker.IsDone()) {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
    }

    //Called when path has been completed, and sets new path if no errors occur
    void OnPathComplete(Path p) 
    {
        if (!p.error) {
            path = p;
        }
    }
}
