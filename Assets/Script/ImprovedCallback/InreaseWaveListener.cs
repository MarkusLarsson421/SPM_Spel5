using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks{
    public class InreaseWaveListener : MonoBehaviour
    {
        private int waveCounter = 0;
        // Start is called before the first frame update
        void Start()
        {
            IncreaseWaveEvent.RegisterListener(addWave);
        }

        private void addWave(IncreaseWaveEvent info)
        {
            ++waveCounter;
        }
        public int GetWaveCounter()
        {
            return waveCounter;
        }

    }
}
