using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour //khal6952
{
    // instruktion är här https://www.youtube.com/watch?v=LIn2jOyOTKQ&t=294s
    [SerializeField] private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    /*@Author Axel Sterner
     * Variabel för att lägga tillbaka prefaben i poolen
     */
    private Zombie zReference;
    private ZombiePool zP;

    private int health = 100;

	private void Start()
    {
        zReference = this;
        zP = ZombiePool.Instance;
        GetReferences();
    }
    private void Update()
    {
        MoveToTarget();
    }

    //@Author Axel Sterner
    public int GetHealth()
    {
        return health;
    }
    
    public int SetHealth(int newHp)
    {
        return health = newHp;
    }

    /**
     * @Author Khaled Alraas
     *
     * Sets the detination to the target
     */
    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
    }
    
    /**
     * @Author Khaled Alraas
     *
     * Gets the Navigation Mesh Agent
     */
    private void GetReferences()
    {
        agent.GetComponent<NavMeshAgent>();
    }
    
    /**
     * @Author Khaled Alraas
     *
     * Used in the zombieSpawnPosition script the set the target
     */
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    
    /**
     * @Author Markus Larsson
     *
     * Removes health from this Zombie.
     */
    public void TakeDamage(int damage){
        health -= damage;
        if(health <= 0)
        {
            Debug.Log("död");
        }
    }
}
