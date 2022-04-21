using UnityEngine;

/**
 * @Author Markus Larsson
 *
 * Class made to create items able to be picked up by the player.
 */
public class Item : MonoBehaviour
{
    [SerializeField] private string name = "Unnamed Item";
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    [SerializeField] private ItemType itemType = ItemType.Random;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;

        gameObject.name = name;
    }

    public ItemType GetType()
    {
        return itemType;
    }
    
    public enum ItemType{
        Random, Ammo, Battery, Scrap, Pistol, FlashLight,
    }
}
