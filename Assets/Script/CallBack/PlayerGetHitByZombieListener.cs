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
            CanvasHandler canvasHandler = playerGetHitByZombieInfo.UnitGO.GetComponentInChildren<CanvasHandler>();
            Debug.Log(playerGetHitByZombieInfo.UnitGO.tag);
            //CanvasHandler tookDamgeCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasHandler>();
            canvasHandler.setFadeIn(true);
            canvasHandler.EnemyAttackedMe();
        }
    }
}
