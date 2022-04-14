using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Simon Hessling Oscarson
//Axel Sterner
public class Interactor : MonoBehaviour
{
    public ResourceManager rM;
    // om det behövs mer instruktioner: https://www.youtube.com/watch?v=lZThP8KG1W0&t=21&ab_channel=JTAGames
    public LayerMask interactableLayerMask = 7;
    public Image interactImage;
    public Sprite defaultIcon;
    public Vector2 defaultIconSize;
    public Sprite defaultInteractionIcon;
    public Vector2 defaultInteractionIconSize;

    Interactable interactable;
    Weapon wpn;
    
    void Update()
    {
        interactHandler();
    }

    void interactHandler()
    {
        RaycastHit hit; //man lägger till vad som händer i onInteract Måste ha Layermask Interactable.
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayerMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false) //makes u interact Only Once. Doesnt update every frame.
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    Debug.Log("interaction Done Once");
                }
                ChangeInteractionIcon();

                if (interactable.gameObject.CompareTag("Ammo") && Input.GetKeyDown(KeyCode.E))
                {
                    rM.PickUp(interactable.gameObject);
                }
            }
        }
        else
        {
            if (interactImage.sprite != defaultIcon)
            {
                interactImage.sprite = defaultIcon;
                interactImage.rectTransform.sizeDelta = defaultIconSize;
            }
        }
    }


    void ChangeInteractionIcon()
    { //also makes it possible to change the size.
        if (interactable.interactIcon != null)
        {
            interactImage.sprite = interactable.interactIcon;
            if (interactable.iconSize == Vector2.zero)
            {
                interactImage.rectTransform.sizeDelta = defaultInteractionIconSize;
            }
            else
            {
                interactImage.rectTransform.sizeDelta = interactable.iconSize;
            }
        }
        else
        {
            interactImage.sprite = defaultInteractionIcon;
            interactImage.rectTransform.sizeDelta = defaultInteractionIconSize;
        }
    }
}
