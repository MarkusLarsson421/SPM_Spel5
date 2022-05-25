using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerIsNearTheCarListener : MonoBehaviour
    {
        private void Start()
        {
            PlayeIsNearTheCarEvent.RegisterListener(PopoutText);
        }

        private void PopoutText(PlayeIsNearTheCarEvent obj)
        {
            CanvasHandler PopOutTextCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasHandler>();
            PopOutTextCanvas.showPopOutText( 10+ "/" + 10 + " Scraps");
        }
    }
}
