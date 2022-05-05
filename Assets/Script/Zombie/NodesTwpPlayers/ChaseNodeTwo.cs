using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseNodeTwo : Node
{
    private Transform target;
    private Transform targetTwo;
    private NavMeshAgent agent;
    private EnemyAI ai;


    public ChaseNodeTwo(Transform target, Transform targetTwo, NavMeshAgent agent, EnemyAI ai)
    {
        this.target = target;
        this.targetTwo = targetTwo;
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        ai.SetColor(Color.yellow);
        float distance = Vector3.Distance(target.position, agent.transform.position);
        float distanceTwo = Vector3.Distance(targetTwo.position, agent.transform.position);
        if (distance > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }else if (distanceTwo > 0.2f)
        {
            agent.isStopped = false;
            agent.SetDestination(targetTwo.position);
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }


}
