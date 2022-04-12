using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    // instruktion �r h�r https://www.youtube.com/watch?v=LIn2jOyOTKQ&t=294s
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform target;

	private void Start()
    {
        GetReferences();
    }
    private void Update()
    {
        MoveToTarget();
    }
    private void MoveToTarget() // sets the detination to the target
    {
        agent.SetDestination(target.position);
    }
    private void GetReferences() // gets the Navigation Mesh Agent
    {
        agent.GetComponent<NavMeshAgent>();
    }
    public void SetTarget(Transform nTarget) // does nothing right now. Khaled will conitnue working with it.
    {
        target = nTarget;
    }
}
