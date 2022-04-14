using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorInteraction : MonoBehaviour
{
    Clickable clickable;
    public LayerMask interactableLayerMask = 8;

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
                if (clickable == null || clickable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    clickable = hit.collider.GetComponent<Clickable>();
                    Debug.Log("interaction Done Once");
                }
                
                if (Input.GetKeyDown(KeyCode.E)) //händer när man klickar E
                {

                    clickable.onInteract.Invoke();

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
