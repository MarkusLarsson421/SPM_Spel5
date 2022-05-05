using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingInRangeNodeTwo : Node
{
    private float range;
    private Transform target;
    private Transform targetTwo;
    private Transform origin;

    public ChasingInRangeNodeTwo(float range, Transform target, Transform targetTwo, Transform origin)
    {
        this.range = range;
        this.target = target;
        this.targetTwo = targetTwo;
        this.origin = origin;
    }
    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.position, origin.position);
        float distanceTwo = Vector3.Distance(targetTwo.position, origin.position);
        RaycastHit hit;
        if (distance <= range || distanceTwo <= range)
        {
            return NodeState.SUCCESS;
        }
        else if (Physics.Raycast(origin.position, target.position - origin.position, out hit) || Physics.Raycast(origin.position, targetTwo.position - origin.position, out hit))
        {
            if (hit.collider.transform == target || hit.collider.transform == targetTwo)
                return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }

}
