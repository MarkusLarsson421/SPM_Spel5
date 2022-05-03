using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthThreshold;
    [SerializeField] private float healthRestoreRate;

    [SerializeField] private float chasingRange;
    [SerializeField] private float shootingRange;

  
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Cover[] avaliableCovers;

   

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

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        material = GetComponentInChildren<MeshRenderer>().material;
    }

    private void Start()
    {
        _currentHealth = startingHealth;
        ConstructBehahaviourTree();
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
        AttackNode shootNode = new AttackNode(agent, this, playerTransform);

        Sequence chaseSequence = new Sequence(new List<Node> { chasingInRangeNode, chaseNode });
        Sequence shootSequence = new Sequence(new List<Node> { shootingRangeNode, shootNode });

        Sequence goToCoverSequence = new Sequence(new List<Node> { coverAvaliableNode, goToCoverNode });
        Selector findCoverSelector = new Selector(new List<Node> { goToCoverSequence, chaseSequence });
        Selector mainCoverSequence = new Selector(new List<Node> { isCoveredNode, findCoverSelector });
        //Sequence mainCoverSequence = new Sequence(new List<Node> { healthNode, tryToTakeCoverSelector });

        topNode = new Selector(new List<Node> { shootSequence, chaseSequence, mainCoverSequence });


    }

    private void Update()
    {
        topNode.Evaluate();
        if(topNode.nodeState == NodeState.FAILURE)
        {
            SetColor(Color.red);
            agent.isStopped = true;
        }
        currentHealth += Time.deltaTime * healthRestoreRate;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
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


}
