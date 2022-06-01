using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EventCallbacks
{
    public class PlayerHealthChangeListener : MonoBehaviour
    {
        [SerializeField] private GameObject gameobj;
        [SerializeField] private Image image;

        // Start is called before the first frame update
        void Start()
        {
            PlayerHealthChangeEvent.RegisterListener(ChangePlayerHealthInPlayerStateCanvas);
        }
        void ChangePlayerHealthInPlayerStateCanvas(PlayerHealthChangeEvent playerHealth)
        {
            ColorModifer colorModifer = gameobj.GetComponent<ColorModifer>();
            colorModifer.setValue(playerHealth.PlayerHealth);
            colorModifer.setImage(image);
        }

    }
}
