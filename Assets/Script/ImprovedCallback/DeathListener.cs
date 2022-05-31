using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class DeathListener : MonoBehaviour
    {
        //public GameObject bloodParticle;
        public AudioClip deathSound;
        public AudioSource speaker;

        // Use this for initialization
        void Start()
        {
            PlayerDieEvent.RegisterListener(DebugListener);
            PlayerDieEvent.RegisterListener(SoundListener);
            PlayerDieEvent.RegisterListener(RemoveListener);
            PlayerDieEvent.RegisterListener(ShowDeathCanvas);
            PlayerDieEvent.RegisterListener(TriggerScoreUpdate);

            //EventSystem.Current.RegisterListener<PlayerDieEvent>(ParticleListener);

        }

        void DebugListener(PlayerDieEvent dieEvent) //DebugListener är dåligt namn
        {
            Debug.Log("Alerted about unit death: " + dieEvent.UnitGO.name);

        }
        void SoundListener(PlayerDieEvent unitDeathInfo) //SoundListener är dåligt namn
        {
           // speaker.PlayOneShot(deathSound); //Ska inte finnas här 

        }
        void RemoveListener(PlayerDieEvent unitDeathInfo) //RemoveListener är dåligt namn
        {
            var unitPrefabClones = GameObject.FindGameObjectsWithTag("Player");
            foreach (var clone in unitPrefabClones)
            {
            }
        }
        void ShowDeathCanvas(PlayerDieEvent unitDeathInfo)
        {
            CanvasHandler deathCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasHandler>();
            deathCanvas.ChangeCanvasToDeathCanvas();
        }

        void TriggerScoreUpdate(PlayerDieEvent unitDeathInfo)
        {
            ScoreSystem scoreSystem = gameObject.GetComponent<ScoreSystem>();
            //scoreSystem.UpdateValues();
        }


    }
}