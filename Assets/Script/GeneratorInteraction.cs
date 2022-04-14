using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInteraction : MonoBehaviour
{
    Interactable interactable;
    public LayerMask interactableLayerMask = 7;

    // Update is called once per frame
    void Update()
    {
        interactHandler();
    }



    void interactHandler()
    {
        RaycastHit hit; 
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false) //makes u interact Only Once. Doesnt update every frame.
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    Debug.Log("interaction Done Once");
                }
                
                if (Input.GetKeyDown(KeyCode.E)) //händer när man klickar E
                {
                    
                    interactable.onInteract.Invoke();

                }
            }
        }
        /*
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
        */
    }
}
