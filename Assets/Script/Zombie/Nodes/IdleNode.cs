using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class IdleNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai; // me

    public IdleNode(NavMeshAgent agent, EnemyAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        if (!agent.isStopped)
        {
            IdleAnimation();

            return NodeState.RUNNING;

        }
        else
        {
            return NodeState.SUCCESS;

        }

    }
    private void IdleAnimation()
    {
        Animator anim = ai.GetComponent<Animator>();
        anim.SetTrigger("Idle");
    }
}
