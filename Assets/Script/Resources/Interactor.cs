using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//Simon Hessling Oscarson
//Axel Sterner
//Martin Wallmark
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
        
        timer += Time.deltaTime;

        if (canInteract) 
        {
            interactHandler();
        }

       

        if (timer >= 0.2f)
        {
            canInteract = true;
        }
        //interactHandler();
        
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started && canInteract)
        {
            isInteractPressed = true;
            /*
            interactHandler();
            if (interactable.gameObject.tag == "CraftingTable")
            {
                interactable.gameObject.GetComponent<CraftingSystem>().playah = this.transform.parent.tag;
            }
            */

        }
        if (context.canceled)
        {
            isInteractPressed = false;
  
        }
    }

    void interactHandler()
    {
        RaycastHit hit; //man lägger till vad som händer i onInteract Måste ha Layermask Interactable.
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 5, interactableLayerMask))
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
                    interactable.interactingGameObject = this.gameObject; //TEST
                    //Experiment
                    if(interactable.gameObject.tag.Equals("CraftingTable"))
                    {
                        interactable.gameObject.GetComponent<CraftingSystem>().playah = this.transform.parent.tag;
                    }
                    
                    if(interactable.gameObject.tag.Equals("Ammo"))
                    {
                        interactable.gameObject.GetComponent<APU_SimonPrototype>().rm = gameObject.GetComponentInChildren<ResourceManager>();
                        interactable.gameObject.GetComponent<Item>().playah = gameObject.transform.parent.tag;

                    }

                    if (interactable.gameObject.tag.Equals("Battery"))
                    {
                        interactable.gameObject.GetComponent<BPU_SimonPrototype>().rm = gameObject.GetComponentInChildren<ResourceManager>();
                        interactable.gameObject.GetComponent<Item>().playah = gameObject.transform.parent.tag;
                    }

                    if (interactable.gameObject.tag.Equals("Scrap"))
                    {
                        interactable.gameObject.GetComponent<SPU_SimonPrototype>().rm = gameObject.GetComponentInChildren<ResourceManager>();
                        interactable.gameObject.GetComponent<Item>().playah = gameObject.transform.parent.tag;
                    }
                    if (interactable.gameObject.tag.Equals("Car"))
                    {
                        interactable.gameObject.GetComponent<WinGame_SimonPrototype>().rm = gameObject.GetComponentInChildren<ResourceManager>();
                        interactable.gameObject.GetComponent<Item>().playah = gameObject.transform.parent.tag;
                    }

                    canInteract = false;
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
            
            timer = 0;
        }

        void ChangeInteractionIcon()
        { //also makes it possible to change the size.
            if (interactable.interactIcon != null)
            {
                //Debug.Log("1");
                interactImage.sprite = interactable.interactIcon;
                if (interactable.iconSize == Vector2.zero)
                {
                    //Debug.Log("2");
                    interactImage.rectTransform.sizeDelta = defaultInteractionIconSize;
                }
                else
                {
                    //Debug.Log("3");
                    interactImage.rectTransform.sizeDelta = interactable.iconSize;
                }
            }
            else
            {
                //Debug.Log("4");
                interactImage.sprite = defaultInteractionIcon;
                interactImage.rectTransform.sizeDelta = defaultInteractionIconSize;
            }
        }
    }

}
