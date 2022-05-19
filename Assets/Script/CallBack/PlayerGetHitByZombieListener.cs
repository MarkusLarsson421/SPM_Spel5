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
        {/*
            CanvasHandler tookDamgeCanvas = gameObject.transform.parent.transform.parent.GetComponentInChildren<CanvasHandler>();
            Debug.Log(gameObject.transform.parent.transform.parent.tag);           
            tookDamgeCanvas.setFadeIn(true);
            tookDamgeCanvas.EnemyAttackedMe();*/
        }
    }
}
