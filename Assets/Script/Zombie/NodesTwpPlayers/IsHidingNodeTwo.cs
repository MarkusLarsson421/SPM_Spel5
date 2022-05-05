using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHidingNodeTwo : Node
{
    private Transform target;
    private Transform targetTwo;
    private Transform origin;

    public IsHidingNodeTwo(Transform target, Transform targetTwo, Transform origin)
    {
        this.target = target;
        this.targetTwo = targetTwo;
        this.origin = origin;
    }


    public override NodeState Evaluate()
    {
        //return NodeState.FAILURE; Om vi vill att zombie gommer sig istället för att vara Idle
        //Om zoblie är tillräckligt nära hide platsen då det är Success.
        RaycastHit hit;
        if (Physics.Raycast(origin.position, target.position - origin.position, out hit) || Physics.Raycast(origin.position, targetTwo.position - origin.position, out hit))
        {
            if (hit.collider.transform != target || hit.collider.transform != targetTwo)
            {
                return NodeState.SUCCESS;
            }
        }
        return NodeState.FAILURE;
    }
}
