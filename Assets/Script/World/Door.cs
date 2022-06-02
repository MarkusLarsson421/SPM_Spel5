using UnityEngine;

/**
 * @Author Markus Larsson
 */
public class Door : Toggleable
{
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
    }

	/**
	 * Closes the door.
	 */
    public override void SetFalse()
    {
        state = false;
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
    public override void SetTrue()
    {
        state = true;
        foreach (Animator a in ani)
        {
            a.SetBool("isOpen", true);
            sm.SoundPlaying("toggleDoor");
        }
    }
	
    private void OnValidate()
    {
        Start();
    }
}