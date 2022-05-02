using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
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
    [SerializeField] private Camera playerCamera;
    Interactable interactable;

    private bool isInteractPressed;

    private bool canInteract = true;
    private float timer;

    void Update()
    {

        if (canInteract) 
        {
            interactHandler();
        }

        timer += Time.deltaTime;

        if (timer >= 0.2f)
        {
            canInteract = true;
        }
        interactHandler();
        
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && canInteract)
        {
            isInteractPressed = true;
            canInteract = false;
        }
        if (context.canceled)
        {
            isInteractPressed = false;
            canInteract = true;
        }
    }

    void interactHandler()
    {
        RaycastHit hit; //man lägger till vad som händer i onInteract Måste ha Layermask Interactable.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 2, interactableLayerMask))
        {
            if (hit.collider.GetComponent<Interactable>() != false) //makes u interact Only Once. Doesnt update every frame.
            {
                if (interactable == null || interactable.ID != hit.collider.GetComponent<Interactable>().ID)
                {
                    interactable = hit.collider.GetComponent<Interactable>();
                    Debug.Log("interaction Done Once");
                }
                ChangeInteractionIcon();

                if (isInteractPressed || Input.GetKeyDown(KeyCode.E))
                {
                    interactable.onInteract.Invoke();
                    //Debug.Log("Interact");
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

}
