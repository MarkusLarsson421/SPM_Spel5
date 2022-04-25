using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] private int health = 100;
	
	/**
	 * @Author Markus Larsson
	 *
	 * Makes the gameobject this script is attached to take damage from other scripts calling it,
	 * for example Weapons.cs.
	 */
	public void TakeDamage(int damage){
		health -= damage;
		if(health <= 0){Destroy(gameObject);}
	}
}
