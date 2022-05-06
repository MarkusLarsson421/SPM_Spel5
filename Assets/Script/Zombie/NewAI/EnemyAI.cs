using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    //[SerializeField] private float lowHealthThreshold;
    //[SerializeField] private float healthRestoreRate;

    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

    public ZombieObjectPooled zOP;
    private EnemyAI zReference;
    private ZombiePool zP;
    
    
    [SerializeField] private Cover[] avaliableCovers;
    private GameObject player;
    private GameObject playerTwo;
    private GameObject target1;
    private GameObject target2;
    private float distance1;
    private float distance2;
    [SerializeField] private Transform playerTransform;

    ChaseNode chaseNode;


    private Material material;
    private Transform bestCoverSpot;
    private NavMeshAgent agent;

    private Node topNode;


    

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

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        ClosestPlayer();
    }
    public void FixPlayerTransform()
    {
        if(player != null || playerTwo != null)
        {
            playerTransform = player.transform;
        }
    }
    private void Start()
    {
        ClosestPlayer();
        _currentHealth = startingHealth;
        FixPlayerTransform();
        ConstructBehahaviourTree();
        zReference = this;
        zP = ZombiePool.Instance;
    }
    private void Update()
    {
        ClosestPlayer();
        topNode.Evaluate();
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.red);
            agent.isStopped = true;
        }
        //currentHealth += Time.deltaTime * healthRestoreRate;
    }

    private void ClosestPlayer()
    {
        
        target1 = GameObject.FindGameObjectWithTag("Player1");
        target2 = GameObject.FindGameObjectWithTag("Player2");
        Debug.Log(target1);
        Debug.Log(target2);
        distance1 = Vector3.Distance(transform.position, target1.transform.position);
        distance2 = Vector3.Distance(transform.position, target2.transform.position);
        if (distance1 < distance2)
        {
            Debug.Log("ett är närmast");
            player = target1;
            
        }
        else
        {
            Debug.Log("två är närmast");
            player = target2;
          
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
        //Debug.Log("ouch");
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

}
