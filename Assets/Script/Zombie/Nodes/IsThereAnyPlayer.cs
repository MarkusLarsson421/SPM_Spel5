using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThereAnyPlayer : Node
{
    private GameObject player;
    private GameObject playerTwo;

    public IsThereAnyPlayer(GameObject player, GameObject playerTwo)
    {
        this.player = player;
        this.playerTwo = playerTwo;
    }

    public override NodeState Evaluate()
    {
        if (player != null || playerTwo != null)
        {
            return NodeState.SUCCESS;
        }

        return NodeState.FAILURE;
    }
}
