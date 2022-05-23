using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class GeneratorIsOnListener : MonoBehaviour
    {
        void Start()
        {
            EventSystem.Current.RegisterListener<GneratorIsOnEvent>(ShowTookDamgeCanvas);
        }

        void ShowTookDamgeCanvas(GneratorIsOnEvent generator)
        {
            GameObject zombie = GameObject.FindGameObjectWithTag("Zombie");
            zombie.GetComponent<EnemyAI>().setChasingRange(1000);
            Debug.Log("iwork");

        }
    }
}
