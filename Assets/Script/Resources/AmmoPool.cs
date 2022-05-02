using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för ammo-objekt som ska spawnas med object pooling.
 */
public class AmmoPool : MonoBehaviour
{
    [SerializeField] private APU_SimonPrototype ammoPrefab;

    private Queue<APU_SimonPrototype> ammoContainer = new Queue<APU_SimonPrototype>();

    public static AmmoPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public APU_SimonPrototype Get()
    {
        if(ammoContainer.Count == 0)
        {
            AddShots(1);
        }

        return ammoContainer.Dequeue();
    }

    private void AddShots(int count)
    {
        for (int i = 0; i < count; i++)
        {
            APU_SimonPrototype ammo = Instantiate(ammoPrefab);
            ammo.gameObject.SetActive(false);
            ammoContainer.Enqueue(ammo);
            Debug.Log(ammoContainer.Count);
        }
    }

    public void ReturnToPool(APU_SimonPrototype ammo)
    {
        ammo.gameObject.SetActive(false);
        ammoContainer.Enqueue(ammo);
    }
}
