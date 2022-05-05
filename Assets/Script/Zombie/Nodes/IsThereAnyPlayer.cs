using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThereAnyPlayer : Node
{
    private GameObject player;

    public IsThereAnyPlayer(GameObject player)
    {
        this.player = player;
    }

    public override NodeState Evaluate()
    {
        if (player != null)
        {
            return NodeState.SUCCESS;
        }
        Debug.Log("FAILURE");
        return NodeState.FAILURE;
    }
}
