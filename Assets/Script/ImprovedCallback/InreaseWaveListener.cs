using UnityEngine;

namespace EventCallbacks{
    public class InreaseWaveListener : MonoBehaviour
    {
        private int waveCounter = 1;
        // Start is called before the first frame update
        void Start()
        {
            IncreaseWaveEvent.RegisterListener(addWave);
        }

        private void addWave(IncreaseWaveEvent wave)
        {
            waveCounter = wave.currentWave;
        }
        public int GetCurrentWave()
        {
            return waveCounter;
        }

    }
}
