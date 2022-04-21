using UnityEngine;

/**
 * @Author Markus Larsson
 *
 * Class made to create items able to be picked up by the player.
 */
public class Item : MonoBehaviour
{
    [SerializeField] private string displayName = "Unnamed Item";
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    [SerializeField] private ItemType itemType = ItemType.Random;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        name = displayName;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
    
    public enum ItemType{
        Random, Ammo, Battery, Scrap, Pistol, FlashLight,
    }
}
