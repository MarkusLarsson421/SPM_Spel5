using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class PlayerGetHitByZombieListener : MonoBehaviour
    {
        [SerializeField] private CanvasHandler canvasHandler;
        private void Start()
        {
            PlayerGetHitByZombieEvent.RegisterListener(ShowTookDamgeCanvas);
        }

        void ShowTookDamgeCanvas(PlayerGetHitByZombieEvent playerGetHitByZombieInfo)
        {
            //CanvasHandler tookDamgePanel = gameObject.transform.parent.transform.parent.GetComponentInChildren<CanvasHandler>();
            //Debug.Log(gameObject.transform.parent.transform.parent.tag);
            canvasHandler.setFadeIn(true);
            canvasHandler.EnemyAttackedMe();
        }
    }
}
