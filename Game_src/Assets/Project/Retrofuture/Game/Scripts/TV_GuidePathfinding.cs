using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TV_GuidePathfinding : MonoBehaviour
{
    public GameObject targetGameObject;
    public float speed;

    private Transform target;
    private CharacterController controller;

    Path path;
    Seeker seeker;

    public bool pathPossible = true;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        targetGameObject = GameObject.FindGameObjectWithTag("Player");
        target = targetGameObject.transform;

        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
        CheckPath();
    }

    private void CheckPath()
    {
        GraphNode node1 = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        GraphNode node2 = AstarPath.active.GetNearest(target.position, NNConstraint.Default).node;

        pathPossible = PathUtilities.IsPathPossible(node1, node2);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            //currentWaypoint = 0;
        }
    }
}