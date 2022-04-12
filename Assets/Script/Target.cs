using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField] private int health = 100;
	
	public void TakeDamage(int damage){
		health -= damage;
		if(health <= 0){Destroy(gameObject);}
	}
}
