using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class AttackWithMaleeListener : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            OnAttackWithMaleeEvent.RegisterListener(SlowPlayerDown);
        }

        private void SlowPlayerDown(OnAttackWithMaleeEvent obj)
        {
            Debug.Log("i work");
        }

    }
}
