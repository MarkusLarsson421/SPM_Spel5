using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class AttackNode : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;
    private Transform target;
    private GameObject player;
    private Vector3 currentVelocity;
    private float smoothDamp;

    public AttackNode(NavMeshAgent agent, EnemyAI ai, Transform target, GameObject player)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        this.player = player;
        smoothDamp = 1f;
    }

    public override NodeState Evaluate()
    {
        agent.isStopped = true;
        ai.SetColor(Color.green);
        Vector3 direction = target.position - ai.transform.position;
        Vector3 currentDirection = Vector3.SmoothDamp(ai.transform.forward, direction, ref currentVelocity, smoothDamp);
        Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector3.up);
        ai.transform.rotation = rotation;
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.HitByZombie();
        return NodeState.RUNNING;
    }


}
