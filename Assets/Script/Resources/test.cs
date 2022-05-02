using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private Type itemType;
    [SerializeField] private Mesh mesh;
    [SerializeField] private Material material;
    [SerializeField] private float radius;
    
    public enum Type{
        Batteries,
        Scrap,
        Ammo,
    }

    private void Start()
    {
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = material;
        gameObject.AddComponent<SphereCollider>().radius = radius;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
}