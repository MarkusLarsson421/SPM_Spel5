using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolster : MonoBehaviour{
	[SerializeField] private int selectedWeapon;
	
    // Start is called before the first frame update
    void Start(){
		SelectWeapon();
	}

    // Update is called once per frame
    void Update()
    {
		//Scroll through weapons.
		if(Input.GetAxis("Mouse ScrollWheel") > 0.0f){
			if(selectedWeapon >= transform.childCount - 1){
				selectedWeapon = 0;
			}else{
				selectedWeapon++;
			}
			SelectWeapon();
		} else if(Input.GetAxis("Mouse ScrollWheel") < 0.0f){
			if(selectedWeapon <= 0){
				selectedWeapon = transform.childCount - 1;
			} else{
				selectedWeapon--;
			}
			SelectWeapon();
		}

		//Weapon select using numbers at the top.
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			selectedWeapon = 0;
			SelectWeapon();
		}else if(Input.GetKeyDown(KeyCode.Alpha2)){
			selectedWeapon = 1;
			SelectWeapon();
		}
	}
    
    
    /**
	 * @Author Markus Larsson
     *
     * Loops through the list of weapons and disables all non-desired weapons and enables the desired ones.
	 */
    private void SelectWeapon(){
	    //Should be improved, alterantive ways of doing this?
		for(int i = 0; i < transform.childCount; i++){
			if(selectedWeapon == i){
				transform.GetChild(i).transform.gameObject.SetActive(true);
			}else{
				transform.GetChild(i).transform.gameObject.SetActive(false);
			}
		}
	}
}
