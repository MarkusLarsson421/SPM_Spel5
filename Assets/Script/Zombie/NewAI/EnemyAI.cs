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
    private void Update()
    {
        ClosestPlayer();
        if (playerOne != null || playerTwo != null)
        {
            //ConstructBehahaviourTree();
            topNode.Evaluate();
            if (topNode.nodeState == NodeState.FAILURE)
            {
                SetColor(Color.red);
                agent.isStopped = true;
            }
        }

        //currentHealth += Time.deltaTime * healthRestoreRate;
    }
    /*
     * @Author Simon Hessling Oscarson
     */
    private void ClosestPlayer()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        if (playerOne == null)
        {
            return;
        }
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        if (playerTwo != null && Vector3.Distance(transform.position, playerTwo.transform.position) < Vector3.Distance(transform.position, playerOne.transform.position))
        {
            Construct(playerTwo);
            return;
        }
        Construct(playerOne);
    }
    void Construct(GameObject chosenPlayer)
    {
        if(chosenPlayer == null) { return; }
        ConstructBehahaviourTree(chosenPlayer, chosenPlayer.transform);

    }

    private void ConstructBehahaviourTree(GameObject player, Transform playerTransform)
    {
        //HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        ChasingInRangeNode chasingInRangeNode = new ChasingInRangeNode(chasingRange, playerTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform);
        AttackNode attackNode = new AttackNode(agent, this, playerTransform, player);
        IdleNode idleNode = new IdleNode(agent, this);
        IsThereAnyPlayer isThereAnyPlayer = new IsThereAnyPlayer(player, playerTwo);
        IsPlayerDeadNode isPlayerDeadNode = new IsPlayerDeadNode(player);
        Sequence playerDeathSequence = new Sequence(new List<Node> { isPlayerDeadNode });

        Sequence chaseSequence = new Sequence(new List<Node> { chasingInRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, attackNode });
        Sequence checkPlayerSequence = new Sequence(new List<Node> { isThereAnyPlayer, playerDeathSequence });

        //Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { checkPlayerSequence, shootSequence, chaseSequence, idleNode });


    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Stun4");

        if (_currentHealth <= 0)
        {
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
