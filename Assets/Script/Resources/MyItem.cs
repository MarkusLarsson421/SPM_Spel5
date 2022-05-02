using UnityEngine;

public class MyItem : MonoBehaviour
{
    [SerializeField] private Type itemType;
    
    public enum Type{
        Batteries,
        Scrap,
        Ammo,
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") == false){return;}
        other.GetComponent<ResourceManager>().Offset(itemType, 1);
        Destroy(gameObject);
    }
}