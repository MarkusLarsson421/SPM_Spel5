using UnityEngine;

/**
 * @Author Markus Larsson
 */
public class Door : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private bool playerCanOpen;
    private Animator[] ani;
    private SoundManager sm;

    private void Start()
    {
        sm = FindObjectOfType<SoundManager>();
        ani = new Animator[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            Animator tmpAni = transform.GetChild(i).GetComponent<Animator>();
            if (tmpAni != null)
            {
                ani[i] = tmpAni;
            }
        }
        //SetState(isOpen);
        SetCanOpen(playerCanOpen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerCanOpen)
        {
            Open();
        }
    }

    /**
	 * Toggle the open-close state of the door.
	 */
    public void ToggleState()
    {
        SetState(!isOpen);
    }

    /**
	 * Set the state of the door.
	 *
	 * @param State the desired state of the door.
	 */
    public void SetState(bool desiredOpen)
    {
        if (desiredOpen)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    /**
	 * Closes the door.
	 */
    public void Close()
    {
        isOpen = false;
        foreach (Animator a in ani)
        {
            if (a != null)
                a.SetBool("isOpen", false);
            sm.SoundPlaying("toggleDoor");
        }
    }

    /**
	 * Opens the door.
	 */
    public void Open()
    {
        isOpen = true;
        foreach (Animator a in ani)
        {
            a.SetBool("isOpen", true);
            sm.SoundPlaying("toggleDoor");
        }
    }

    public void SetCanOpen(bool desiredState)
    {
        playerCanOpen = desiredState;
    }

    /**
	 * Updates the light if the inspectorState value has been updated.
	 */
    private void OnValidate()
    {
        Start();
    }
}