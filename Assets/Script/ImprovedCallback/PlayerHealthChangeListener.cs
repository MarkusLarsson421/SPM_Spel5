using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerHealthChangeListener : MonoBehaviour
    {
        //[SerializeField] CanvasHandler playerStateCanvas;
        [SerializeField] private GameObject colorModifer;
        // Start is called before the first frame update
        void Start()
        {
            PlayerHealthChangeEvent.RegisterListener(ChangePlayerHealthInPlayerStateCanvas);
        }
        void ChangePlayerHealthInPlayerStateCanvas(PlayerHealthChangeEvent playerHealth)
        {
            ColorModifer color = colorModifer.GetComponent<ColorModifer>();
            //playerStateCanvas.UpdatePlayerStats(playerHealth.PlayerHealth);
            color.setValue(playerHealth.PlayerHealth);
        }

    }
}
