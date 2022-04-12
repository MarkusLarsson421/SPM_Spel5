using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Weapon : MonoBehaviour{
	[SerializeField] private int damage = 20;
	[SerializeField] private float range = 100.0f;
	
	[SerializeField] private Camera fpsCamera;
	
	private byte ammo = 32;

	void Update(){
		if(true){ //TODO replace true condition with an input condition. Talk to Axel about it.
			if(ammo > 0){
				Fire();
			} else{
				//TODO play empty mag sound?
			}
			
		}
	}

	private void Fire(){
		//ammo -= 1;
		
		RaycastHit hit;
		if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
			Debug.Log(hit.transform.name);
			Zombie zombie = hit.transform.GetComponent<Zombie>();
			if(zombie == null){
				Debug.Log("NOT A ZOMBIE");
				return;
			}
			Debug.Log("HIT A ZOMBIE!");
			zombie.TakeDamage(damage);
		}
	}
}