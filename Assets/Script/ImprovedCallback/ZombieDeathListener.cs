using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EventCallbacks
{/*@Author Khaled Alraas & Axel Sterner
    */
    public class ZombieDeathListener : MonoBehaviour // khaled Alraas gjort själva drop systemet
    {
        private int deathCounter;
        private int deathCounter2;
        private bool checkp2;
        //float range;
        // const float battery_dropChance = 2f / 10f;
        //const float battery_dropChance = 100f;
        //const float scrap_dropChance = 5f / 10f;

        // Start is called before the first frame update
        void Start()
        {
            OnZombieDeathEvent.RegisterListener(GetDeathCounter);
        }
        private void Update()
        {
            //range = Random.Range(0f, 1f);
        }
        private void GetDeathCounter(OnZombieDeathEvent player)
        {
            if (player.name == "Player2")
            {
                ++deathCounter2;
                checkp2 = true;
            }
            else ++deathCounter;
        }
        public int GetDeathCounter()
        {
            return deathCounter;
        }
        //private void DropItems(OnZombieDeathEvent obj)
        //{
        //    //if (battery_dropChance == 100.0f)
        //    //{

        //    //}
        //}
        public bool CheckPlayer2()
        {
            return checkp2;

        }
        public int GetDeathCounter2()
        {
            return deathCounter2;
        }
    }
}
