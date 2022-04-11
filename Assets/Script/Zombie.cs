using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform target;

    private void Start()
    {
        agent.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        agent.SetDestination(target.position);
    }
    private void MoveToTarget()
    {

        agent.SetDestination(target.position);
    }
    private void GetReferences()
    {
        agent.GetComponent<NavMeshAgent>();
    }
}
