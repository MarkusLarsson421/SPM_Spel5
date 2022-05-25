using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    /*
    * Zombie object
    * @Author Khaled Alraas
    */

    [SerializeField] private float startingHealth;
    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;
    int counter = 0;

    public ZombieObjectPooled zOP;
    private EnemyAI zReference;
    private ZombiePool zP;
    public Vector3 spawnPosition;

    private GameObject playerOne;
    private GameObject playerTwo;

    private Material material;
    private NavMeshAgent agent;
    private Node topNode;

    [SerializeField] Animator anim;
    private float timer = 0f;
    private float timer2 = 0f;
    private bool allFounded = false;
    private GameObject chosenPlayer;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
        agent.acceleration = 10;
        agent.speed = 5.1f;
    }
    private void Start()
    {
        zReference = this;
        zP = ZombiePool.Instance;
    }
    GameObject currentPlayer = null;

    private void Update()
    {
        Tasks();
    }
    void Tasks()
    {
        TasksWithTimer();
        if (chosenPlayer != currentPlayer)
        {
            currentPlayer = chosenPlayer;
            ConstructBehahaviourTree(chosenPlayer, chosenPlayer.transform);
        }
        if (playerOne == null)
        {
            return;
        }
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            agent.isStopped = true;
        }
        
    }
    void TasksWithTimer()
    {
        if (timer < 2f && !allFounded) timer += Time.deltaTime;
        else
        {
            //Debug.Log(++counter);
            timer = 0f;
            if (playerOne == null) playerOne = GameObject.FindGameObjectWithTag("Player1");
            else if (playerTwo == null) { playerTwo = GameObject.FindGameObjectWithTag("Player2"); allFounded = true; }
        }
        if (timer2 < 1f) timer2 += Time.deltaTime;
        else
        {
            chosenPlayer = ClosestPlayer();
            if (chosenPlayer != currentPlayer)
            {
                currentPlayer = chosenPlayer;
                ConstructBehahaviourTree(chosenPlayer, chosenPlayer.transform);
            }
        }
    }
    /*
     * @Author Simon Hessling Oscarson
     * @Khaled Alraas
     */
    private GameObject ClosestPlayer()
    {
        if (playerOne == null)
        {
            return null;
        }
        if (playerTwo != null && Vector3.Distance(transform.position, playerTwo.transform.position) < Vector3.Distance(transform.position, playerOne.transform.position))
        {

            return playerTwo;
        }
        return playerOne;
    }

    private void ConstructBehahaviourTree(GameObject player, Transform playerTransform)
    {
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        InRageTochaseNode inRageTochaseNode = new InRageTochaseNode(chasingRange, playerTransform, transform);
        InRangeToAttackNode inRangeToAttackNode = new InRangeToAttackNode(shootingRange, playerTransform, transform);
        AttackNode attackNode = new AttackNode(agent, this, playerTransform, player);
        IdleNode idleNode = new IdleNode(agent, this);
        IsThereAnyPlayer isThereAnyPlayerNode = new IsThereAnyPlayer(player, playerTwo);
        IsPlayerDeadNode isPlayerDeadNode = new IsPlayerDeadNode(player);

        Sequence chaseSequence = new Sequence(new List<Node> { inRageTochaseNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { inRangeToAttackNode, attackNode });

        topNode = new Selector(new List<Node> { isPlayerDeadNode, shootSequence, chaseSequence, idleNode });
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Stun4");
        if (_currentHealth <= 0)
        {
            Debug.Log(++counter);
            /*Debug.Log("returned");
            zOP.DecreaseZombies();
            gameObject.transform.position = spawnPosition;
            zP.ReturnToPool(zReference);*/
            StartCoroutine(PlayDeathAnimation(1.65f));
        }
    }

    //temp death animation nyman
    IEnumerator PlayDeathAnimation(float time)
    {
        anim.SetTrigger("Die");
        anim.SetBool("CanAttack", false);
        agent.isStopped = true;
        yield return new WaitForSeconds(time);
        agent.isStopped = false;
        anim.SetBool("CanAttack", true);
        Debug.Log("returned");
        zOP.DecreaseZombies();
       // gameObject.transform.position = spawnPosition;
        zP.ReturnToPool(zReference);
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    //public void TakeDamage(int damage)
    //{
    //    _currentHealth -= damage;
    //}
    // Under is not in use
    private float _currentHealth;
    public float currentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, 0, startingHealth); }
    }

    public float SetHealth()
    {
        return currentHealth = startingHealth;
    }
    public void setChasingRange(int chasingRange)
    {
        Debug.Log("setChasingRange work");
        this.chasingRange = chasingRange;
    }

}
/*
 private void Start()
    {
        _currentHealth = startingHealth;
        ConstructBehahaviourTree();
    }
 */
