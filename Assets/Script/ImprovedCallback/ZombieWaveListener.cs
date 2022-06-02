using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace EventCallbacks
{

    public class ZombieWaveListener : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI waveText;
        private int waveCounter = 0;
        // Start is called before the first frame update
        void Start()
        {
            IncreaseWaveEvent.RegisterListener(addWave);
        }
        private void Update()
        {
            waveText.text = waveCounter.ToString();
        }

        private void addWave(IncreaseWaveEvent info)
        {
            ++waveCounter;
        }

    }
}