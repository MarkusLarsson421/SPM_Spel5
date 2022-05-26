using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class AttackWithMaleeListener : MonoBehaviour
    {
        float originalmaxSpead;
        float speed;
        DynamicMovementController d;
        // Start is called before the first frame update
        void Start()
        {
            OnAttackWithMaleeEvent.RegisterListener(SlowPlayerDown);
        }
        int counter = 0;
        int counter2 = 0;
        private float timer = 0;
        private void SlowPlayerDown(OnAttackWithMaleeEvent obj)
        {
            ++counter;
            d = obj.player;
            originalmaxSpead = d.getMaxSpeed();
            d.setMaxSpeed(1);
                StartCoroutine(BugFix());
        }
        IEnumerator BugFix()
        {
            yield return new WaitForSeconds(1);
            if (counter > 2) counter--;
            else { 
            d.setMaxSpeed(7);
            counter--;
            }
        }

    }
}
