using UnityEngine;

public class SPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public SubsScript ss;

    

    public void PickUpScrap()
    {
		/*if (ss != null && ss.GetFirstScrapPickUp())
        {
            Debug.Log("funkar");
            ss.scrapPickUpLine = true;
            Debug.Log(ss.scrapPickUpLine);
            ss.SetFirstScrapPickUp(false);
            
        }*/
        rm.Offset(ResourceManager.ItemType.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(ResourceManager.ItemType.Scrap));
        Destroy(gameObject);
    }
}
