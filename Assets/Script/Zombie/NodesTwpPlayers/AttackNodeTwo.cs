using UnityEngine;
using UnityEngine.AI;

public class AttackNodeTwo : Node
{
    private NavMeshAgent agent;
    private EnemyAI ai;
    private Transform target;
    private Transform targetTwo;
    private GameObject player;
    private GameObject playerTwo;

    private Vector3 currentVelocity;
    private float smoothDamp;

    public AttackNodeTwo(NavMeshAgent agent, EnemyAI ai, Transform target, Transform targetTwo, GameObject player, GameObject playerTwo)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        this.targetTwo = targetTwo;
        this.player = player;
        this.playerTwo = playerTwo;
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
