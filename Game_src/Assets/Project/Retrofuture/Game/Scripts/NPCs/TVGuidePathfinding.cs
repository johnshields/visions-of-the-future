using UnityEngine;
using Pathfinding;

/*
 * TVGuidePathfinding
 * Modified version for 1950's level of the Script Rory found.
 */
public class TVGuidePathfinding : MonoBehaviour
{
    public GameObject targetGameObject;
    private Transform target;
    private Seeker seeker;
    public bool pathPossible = true;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        targetGameObject = GameObject.FindGameObjectWithTag("Player");
        target = targetGameObject.transform;
        // Update and Checking the changing path.
        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
        CheckPath();
    }

    // Checking if path is possible on the A* Algorithm.
    private void CheckPath()
    {
        var node1 = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        var node2 = AstarPath.active.GetNearest(target.position, NNConstraint.Default).node;
        pathPossible = PathUtilities.IsPathPossible(node1, node2);
    }

    // Update Path once last Path is done
    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, null);
        }
    }
}