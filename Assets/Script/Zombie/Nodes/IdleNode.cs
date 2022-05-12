using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class IdleNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai; // me
    private Transform target;
    private GameObject player;

    private Vector3 currentVelocity;
    private float smoothDamp;

    public IdleNode(NavMeshAgent agent, EnemyAI ai, Transform target, GameObject player)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        this.player = player;
        smoothDamp = 1f;
    }

    public override NodeState Evaluate()
    {
        if (!agent.isStopped)
        {
            agent.isStopped = true;
            return NodeState.RUNNING;

        }
        else
        {
            return NodeState.SUCCESS;

        }
        //@Martin Nyman Här !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        // "ai" är GameObject som du kan referera till om du behöver
    }
}
