using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRageTochaseNode : Node
{
    private float range;
    private Transform target;
    private Transform origin;

    public InRageTochaseNode(float range, Transform target, Transform origin)
    {
        this.range = range;
        this.target = target;
        this.origin = origin;
    }
    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.position, origin.position);
        RaycastHit hit;
        if (distance <= range)
        {
            return NodeState.SUCCESS;
        }else if (Physics.Raycast(origin.position, target.position - origin.position, out hit))
        {
            if(hit.collider.transform == target)
                return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }

}
