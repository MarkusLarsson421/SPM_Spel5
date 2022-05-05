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

    private EnemyAI zReference;
    private ZombiePool zP;

    [SerializeField] private Cover[] avaliableCovers;
    private GameObject player;
    private GameObject playerTwo;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerTwoTransform;


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

    }

    private void Start()
    {
        _currentHealth = startingHealth;
        zReference = this;
        zP = ZombiePool.Instance;
    }

    private void ConstructBehahaviourTree()
    {
        IsThereAnyAvaliableHidingPlaceNode coverAvaliableNode = new IsThereAnyAvaliableHidingPlaceNode(avaliableCovers, playerTransform, this);
        GoToHidingPlaceNode goToCoverNode = new GoToHidingPlaceNode(agent, this);
        //HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        IsHidingNode isCoveredNode = new IsHidingNode(playerTransform, transform);
        ChaseNode chaseNode = new ChaseNode(playerTransform, agent, this);
        ChasingInRangeNode chasingInRangeNode = new ChasingInRangeNode(chasingRange, playerTransform, transform);
        RangeNode shootingRangeNode = new RangeNode(shootingRange, playerTransform, transform);
        AttackNode attackNode = new AttackNode(agent, this, playerTransform, player);
        IsThereAnyPlayer isThereAnyPlayer = new IsThereAnyPlayer(player);
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
    private void CheeeeeeezyConstructBehahaviourTree()
    {
        IsThereAnyAvaliableHidingPlaceNodetWO coverAvaliableNode = new IsThereAnyAvaliableHidingPlaceNodetWO(avaliableCovers, playerTransform, playerTwoTransform, this);
        GoToHidingPlaceNode goToCoverNode = new GoToHidingPlaceNode(agent, this);
        //HealthNode healthNode = new HealthNode(this, lowHealthThreshold);
        IsHidingNodeTwo isCoveredNode = new IsHidingNodeTwo(playerTransform, playerTwoTransform, transform);
        ChaseNodeTwo chaseNode = new ChaseNodeTwo(playerTransform, playerTwoTransform, agent, this);
        ChasingInRangeNodeTwo chasingInRangeNode = new ChasingInRangeNodeTwo(chasingRange, playerTransform, playerTwoTransform, transform);
        RangeNodeTwo shootingRangeNode = new RangeNodeTwo(shootingRange, playerTransform, playerTwoTransform, transform);
        AttackNodeTwo attackNode = new AttackNodeTwo(agent, this, playerTransform, playerTwoTransform, player, playerTwo);
        IsThereAnyPlayerTwo isThereAnyPlayer = new IsThereAnyPlayerTwo(player, playerTwo);
        IsPlayerDeadNodeTwo isPlayerDeadNode = new IsPlayerDeadNodeTwo(player, playerTwo);

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
    bool temp = true;
    bool tempTwo  = true;
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        checkPlayers();
        //currentHealth += Time.deltaTime * healthRestoreRate;
        if (player != null && playerTwo != null)
        {
            if (tempTwo)
            {
                playerTwoTransform = playerTwo.transform;
                CheeeeeeezyConstructBehahaviourTree();
                tempTwo = false;
            }
        }
        if (player != null)
        {
            if (temp)
            {
                playerTransform = player.transform;
                ConstructBehahaviourTree();
                temp = false;
            }
            topNode.Evaluate();
        }


    }
    private IEnumerator checkPlayers()
    {
        yield return new WaitForSeconds(10);
        if (topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.red);
            agent.isStopped = true;
        }
    }


    public void TakeDamage(float damage)
    {
        //Debug.Log("ouch");
        currentHealth -= damage;
        if (_currentHealth <= 0)
        {
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
