using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform target;

	private int health = 100;

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
    public void SetTarget(Transform nTarget)
    {
        target = nTarget;
    }

	public void TakeDamage(int damage){
		health -= damage;
		if(health <= 0){ Destroy(this); }
	}
}
