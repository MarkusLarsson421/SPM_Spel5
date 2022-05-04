using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerHealthChangeListener : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            EventSystem.Current.RegisterListener<PlayerHealthChangeEvent>(ChangePlayerHealthInPlayerStateCanvas);

        }
        void ChangePlayerHealthInPlayerStateCanvas(PlayerHealthChangeEvent playerHealthChange)
        {
            CanvasHandler playerStateCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasHandler>();
            PlayerStats playerStats = playerHealthChange.UnitGO.GetComponent<PlayerStats>();
            playerStateCanvas.UpdatePlayerStats(playerStats.getHealth());

        }

    }
}
