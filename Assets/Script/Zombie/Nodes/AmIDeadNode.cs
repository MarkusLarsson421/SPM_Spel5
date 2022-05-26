using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIDeadNode : Node
{
    private EnemyAI ai;

    public AmIDeadNode(EnemyAI ai)
    {
        this.ai = ai;
    }
    public override NodeState Evaluate()
    {
        return ai.currentHealth <= 0 ? NodeState.SUCCESS : NodeState.FAILURE;

    }
}
