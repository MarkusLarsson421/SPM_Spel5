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
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats.IsDead())
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
