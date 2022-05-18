using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*@Author Axel Sterner
 * Databehållare för scrap-objekt som ska spawnas med object pooling.
 */
public class ScrapPool : MonoBehaviour
{
    [SerializeField] private SPU_SimonPrototype scrapPrefab;

    private Queue<SPU_SimonPrototype> scrapContainer = new Queue<SPU_SimonPrototype>();
    public static ScrapPool Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    public SPU_SimonPrototype Get()
    {
        if(scrapContainer.Count == 0)
        {
            AddScrap(1);
        }
        return scrapContainer.Dequeue();
    }

    private void AddScrap(int count)
    {
        for(int i = 0; i < count; i++)
        {
            SPU_SimonPrototype scrap = Instantiate(scrapPrefab);
            scrap.gameObject.SetActive(false);
            scrapContainer.Enqueue(scrap);
        }
    }

    public void ReturnToPool(SPU_SimonPrototype scrap)
    {
        scrap.gameObject.SetActive(false);
        scrapContainer.Enqueue(scrap);
    }
}
