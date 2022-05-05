using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThereAnyPlayerTwo : Node
{
    private GameObject player;
    private GameObject playerTwo;

    public IsThereAnyPlayerTwo(GameObject player, GameObject playerTwo)
    {
        this.player = player;
        this.playerTwo = playerTwo;
    }

    public override NodeState Evaluate()
    {
        if (player != null)
        {
            return NodeState.SUCCESS;
        }else if (playerTwo != null){
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
