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
    //[SerializeField] private float lowHealthThreshold;
    //[SerializeField] private float healthRestoreRate;

    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

    public ZombieObjectPooled zOP;
    private EnemyAI zReference;
    private ZombiePool zP;


    [SerializeField] private Cover[] avaliableCovers;
    private GameObject playerOne;
    private GameObject playerTwo;
    private float distance1;
    private float distance2;
    private GameObject player;
    [SerializeField] private Transform playerTransform;

    ChaseNode chaseNode;


    private Material material;
    private Transform bestCoverSpot;
    private NavMeshAgent agent;

    private Node topNode;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
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
            ConstructBehahaviourTree();
            topNode.Evaluate();
            if (topNode.nodeState == NodeState.FAILURE)
            {
                SetColor(Color.red);
                agent.isStopped = true;
            }
        }

        //currentHealth += Time.deltaTime * healthRestoreRate;
    }
    bool one = true;
    bool two = true;
    /*
     * @Author Simon Hessling Oscarson
     */
    private void ClosestPlayer()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        if (playerOne != null)
        {
            player = playerOne;
            playerTransform = playerOne.transform;
            playerTwo = GameObject.FindGameObjectWithTag("Player2");
            if (playerTwo != null)
            {
                distance1 = Vector3.Distance(transform.position, playerOne.transform.position);
                distance2 = Vector3.Distance(transform.position, playerTwo.transform.position);
                if (distance2 < distance1)
                {
                    Debug.Log("två är närmast");
                    player = playerTwo;
                    playerTransform = playerTwo.transform;
                    if (two)
                    {
                        ConstructBehahaviourTree();
                        two = false;
                    }
                }
                //else one = true;
            }
            else if (one)
            {
                ConstructBehahaviourTree();
                one = false;
                two = true;
            }
        }
    }

    private void ConstructBehahaviourTree()
    {
        IsThereAnyAvaliableHidingPlaceNode coverAvaliableNode = new IsThereAnyAvaliableHidingPlaceNode(avaliableCovers, playerTransform, this);
        GoToHidingPlaceNode goToCoverNode = new GoToHidingPlaceNode(agent, this);
        //HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        IsHidingNode isCoveredNode = new IsHidingNode(playerTransform, transform);
        chaseNode = new ChaseNode(playerTransform, agent, this);
        ChasingInRangeNode chasingInRangeNode = new ChasingInRangeNode(chasingRange, playerTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform);
        AttackNode attackNode = new AttackNode(agent, this, playerTransform, player);
        IsThereAnyPlayer isThereAnyPlayer = new IsThereAnyPlayer(player, playerTwo);
        IsPlayerDeadNode isPlayerDeadNode = new IsPlayerDeadNode(player);
        Sequence playerDeathSequence = new Sequence(new List<Node> { isPlayerDeadNode });

        Sequence chaseSequence = new Sequence(new List<Node> { chasingInRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, attackNode });
        Sequence checkPlayerSequence = new Sequence(new List<Node> { isThereAnyPlayer, playerDeathSequence });

        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvaliableNode, goToCoverNode });
        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });
        Selector mainCoverSequence = new Selector(new List<Node> { isCoveredNode, findCoverSelector });
        //Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { checkPlayerSequence, shootSequence, chaseSequence, mainCoverSequence });


    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Debug.Log("returned");
            zOP.DecreaseZombies();

            zP.ReturnToPool(zReference);
        }
    }

    public void SetColor(Color color)
    {
        material.color = color;
    }

    public void SetBestCoverSpot(Transform bestCoverSpot)
    {
        this.bestCoverSpot = bestCoverSpot;
    }

    public Transform GetBestCoverSpot()
    {
        return bestCoverSpot;
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
}
/*
 private void Start()
    {
        _currentHealth = startingHealth;
        ConstructBehahaviourTree();
    }
 */
