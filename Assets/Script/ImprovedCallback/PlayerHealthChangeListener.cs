using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerHealthChangeListener : MonoBehaviour
    {
        [SerializeField] private ColorModifer colorModifer;
        // Start is called before the first frame update
        void Start()
        {
            PlayerHealthChangeEvent.RegisterListener(ChangePlayerHealthInPlayerStateCanvas);
        }
        void ChangePlayerHealthInPlayerStateCanvas(PlayerHealthChangeEvent playerHealth)
        {
            colorModifer.setValue(playerHealth.PlayerHealth);
        }

    }
}
