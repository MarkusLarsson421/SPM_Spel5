using UnityEngine;

public class Weapon : MonoBehaviour{
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	
	[SerializeField] private Camera fpsCamera;
	
	private byte ammo = 32;

	void Update(){
		if(true){ //TODO replace true condition with an input condition. Talk to Axel about it.
			Fire();
		}
	}

	private void Fire(){
		//ammo -= 1;
		
		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);
			Target target = hit.transform.GetComponent<Target>();
			if(target != null){
				Debug.Log("HIT A ZOMBIE!");
				target.TakeDamage(damage);
			}
		}
	}
}