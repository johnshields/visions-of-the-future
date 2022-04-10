using UnityEngine;
using Pathfinding;

public class TV_GuidePathfinding : MonoBehaviour
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

        InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
        CheckPath();
    }

    private void CheckPath()
    {
        var node1 = AstarPath.active.GetNearest(transform.position, NNConstraint.Default).node;
        var node2 = AstarPath.active.GetNearest(target.position, NNConstraint.Default).node;

        pathPossible = PathUtilities.IsPathPossible(node1, node2);
    }

    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, null);
        }
    }
}