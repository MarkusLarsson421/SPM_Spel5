using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

//Axel Sterner

public class ResourceManager : MonoBehaviour{
    //private Dictionary<string, int> inventory = new Dictionary<string, int>();
	
    private int ammoCap = 100;
    private int scrapCap = 10;
    private int batteryCap = 3; //maxantal
    private int pickUpQuant;
    private int scrapCount = 0;
    private int batteryCount = 0;
    private string itemTag;
    public Weapon wpn;

    private int MINAMMOPICKUP = 10;
    private int MAXAMMOPICKUP = 40;
    private int MINSCRAPPICKUP = 3;
    private int MAXSCRAPPICKUP = 6;
    
    void Start(){
        
    }

    void Update()
    {

    }

	/**
	 * @Author Axel Sterner and Markus Larsson
	 * 
	 * 
	 */
    public void PickUp(GameObject g)
    {
        itemTag = g.tag;
        switch (itemTag)
        {
            case "Ammo":
                if(wpn.GetAmmo() == 100)
                {
                    return;
                }
                else
                {
                    AmmoHandler(g);
                    Destroy(g);
                }
                break;

            case "Scrap":
                ItemHandler(g);
                if(scrapCount < scrapCap - pickUpQuant)
                {
                    scrapCount += pickUpQuant;
                    Debug.Log(scrapCount);
                    Destroy(g);
                }
                break;

            case "Battery":
                ItemHandler(g);
                if(batteryCount < batteryCap - pickUpQuant)
                {
                    batteryCount += pickUpQuant;
                    Debug.Log(batteryCount);
                    //Destory(g);
                }
                Debug.Log("Quantity: " + pickUpQuant);
                break;
        }
    }
   
    private void ItemHandler(GameObject g)
    {
        pickUpQuant = 3;
       
    }

    private void AmmoHandler(GameObject g)
    {
        pickUpQuant = Random.Range(MINAMMOPICKUP, MAXAMMOPICKUP);
        Debug.Log("Antal: " + pickUpQuant);
        int currentAmmo = wpn.GetAmmo();
        if(currentAmmo + pickUpQuant > 100)
        {
            wpn.ResetAmmo();
            Debug.Log(wpn.GetAmmo());
        }
        else
        {
            wpn.SetAmmo(pickUpQuant);
            Debug.Log("Total ammo: " + wpn.GetAmmo());
        }

    }

    private void ScrapHandler(GameObject g)
    {
        pickUpQuant = Random.Range(MINSCRAPPICKUP, MAXSCRAPPICKUP);
    }
    /*
     * 
     * */
}
