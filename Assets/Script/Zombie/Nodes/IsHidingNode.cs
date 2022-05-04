using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHidingNode : Node
{
    private Transform target;
    private Transform origin;

    public IsHidingNode(Transform target, Transform origin)
    {
        this.target = target;
        this.origin = origin;
    }

    public override NodeState Evaluate()
    {
        //return NodeState.FAILURE; Om vi vill att zombie gommer sig istället för att vara Idle
        //Om zoblie är tillräckligt nära hide platsen då det är Success.
        RaycastHit hit;
        if(Physics.Raycast(origin.position, target.position - origin.position, out hit))
        {
            if(hit.collider.transform != target)
            {
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}
