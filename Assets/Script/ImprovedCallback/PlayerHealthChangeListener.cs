using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerHealthChangeListener : MonoBehaviour
    {
        CanvasHandler playerStateCanvas;
        [SerializeField]private ColorModifer colorModifer;
        // Start is called before the first frame update
        void Start()
        {
            PlayerHealthChangeEvent.RegisterListener(ChangePlayerHealthInPlayerStateCanvas);
            playerStateCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasHandler>();
        }
        void ChangePlayerHealthInPlayerStateCanvas(PlayerHealthChangeEvent playerHealthChange)
        {
            
            playerStateCanvas.UpdatePlayerStats(playerHealthChange.PlayerHealth);
            colorModifer.setValue(playerHealthChange.PlayerHealth);
        }

    }
}
