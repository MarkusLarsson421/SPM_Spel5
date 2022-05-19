using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerGetHitByZombieListener : MonoBehaviour
    {
        void Start()
        {
            EventSystem.Current.RegisterListener<PlayerGetHitByZombieEvent>(ShowTookDamgeCanvas);
        }

        void ShowTookDamgeCanvas(PlayerGetHitByZombieEvent playerGetHitByZombieInfo)
        {
            CanvasHandler tookDamgeCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasHandler>();
            tookDamgeCanvas.setFadeIn(true);
            tookDamgeCanvas.EnemyAttackedMe();
        }
    }
}
