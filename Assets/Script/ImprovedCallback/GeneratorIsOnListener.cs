using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class GeneratorIsOnListener : MonoBehaviour
    {
        void Start()
        {
            GneratorIsOnEvent.RegisterListener(ShowTookDamgeCanvas);
        }

        void ShowTookDamgeCanvas(GneratorIsOnEvent generator)
        {
            GameObject zombie = GameObject.FindGameObjectWithTag("Zombie");
            zombie.GetComponent<EnemyAI>().setChasingRange(1000);
            Debug.Log("GeneratorIsOnListener work");

        }
    }
}
