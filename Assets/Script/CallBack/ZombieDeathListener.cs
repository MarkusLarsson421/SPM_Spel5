using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCallbacks
{/*@Author Khaled Alraas & Axel Sterner
    */
    public class ZombieDeathListener : MonoBehaviour // khaled Alraas gjort själva drop systemet
    {
        float range;
        // const float battery_dropChance = 2f / 10f;
        const float battery_dropChance = 100f;
        const float scrap_dropChance = 5f / 10f;

        // Start is called before the first frame update
        void Start()
        {
            OnZombieDeathEvent.RegisterListener(DropItems);
        }
        float timer = 0f;
        private void DropItems(OnZombieDeathEvent obj)
        {
            if (timer == 0) timer += Time.deltaTime;
            else
            {
                timer = 0;
                range = Random.Range(0f, 1f);
            }

            if (battery_dropChance == 100.0f)
            {
                
            }
        }
    }
}
