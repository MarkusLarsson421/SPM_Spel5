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
            ss.SetFirstScrapPickUp(false);
            Debug.Log(ss.scrapPickUpLine);
        }
        rm.Offset(MyItem.Type.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(MyItem.Type.Scrap));
        Destroy(gameObject);
    }
}
