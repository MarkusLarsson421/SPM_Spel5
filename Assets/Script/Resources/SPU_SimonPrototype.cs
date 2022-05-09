using UnityEngine;

public class SPU_SimonPrototype : MonoBehaviour
{
    public ResourceManager rm;
    public SubsScript ss;

    private bool firstScrapPickedUp;

    public void PickUpScrap()
    {
		if (firstScrapPickedUp == false)
        {
			firstScrapPickedUp = true;
            ss.scrapPickUpLine = true;
		}
        rm.Offset(MyItem.Type.Scrap, 1);
        Debug.Log("totalt antal scraps " + rm.Get(MyItem.Type.Scrap));
        Destroy(gameObject);
    }
}
