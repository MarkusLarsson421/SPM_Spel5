using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerDeadNodeTwo : Node
{
    private GameObject player;
    private GameObject playerTwo;

    public IsPlayerDeadNodeTwo(GameObject player, GameObject playerTwo)
    {
        this.player = player;
        this.playerTwo = playerTwo;
    }

    public override NodeState Evaluate()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        PlayerStats playerStatsTwo = playerTwo.GetComponent<PlayerStats>();
        if (playerStats.IsDead() && playerStatsTwo.IsDead())
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}
