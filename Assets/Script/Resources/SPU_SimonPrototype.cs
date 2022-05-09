using UnityEngine;

public class SPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public SubsScript ss;

    

    public void PickUpScrap()
    {
		if (ss.GetFirstScrapPickUp())
        {
            Debug.Log("funkar");
            ss.scrapPickUpLine = true;
            Debug.Log(ss.scrapPickUpLine);
            ss.SetFirstScrapPickUp(false);
            
        }
        rm.Offset(MyItem.Type.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(MyItem.Type.Scrap));
        Destroy(gameObject);
    }
}
