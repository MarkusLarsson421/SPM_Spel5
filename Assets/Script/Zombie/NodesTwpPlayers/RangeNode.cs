using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNodeTwo : Node
{
    private float range;
    private Transform target;
    private Transform targetTwo;
    private Transform origin;

    public RangeNodeTwo(float range, Transform target, Transform targetTwo, Transform origin)
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
        if (distance <= range|| distanceTwo <= range)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
