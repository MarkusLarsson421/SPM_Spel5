using System;
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
	 * Opens the door.
	 */
	[ContextMenu("Open Door")]
    public override void SetTrue()
    {
		Debug.Log("Opening door!");
        state = true;
        foreach (Animator a in ani)
        {
            if (a.GetBool("isOpen") == false)
            {

                sm.SoundPlaying("toggleDoor");
            }
            a.SetBool("isOpen", true);
        }
    }
	
	/**
	 * Closes the door.
	 */
	[ContextMenu("Close Door")]
    public override void SetFalse()
    {
		Debug.Log("Closing door!");
        state = false;
        foreach (Animator a in ani)
        {
            if (a != null)
            if (a.GetBool("isOpen") == true)
            {

                sm.SoundPlaying("toggleDoor");

            }
            a.SetBool("isOpen", false);
        }
    }
	
    private void OnValidate()
    {
        Start();
    }
	
	public virtual object CaptureState(){
		Debug.Log("Captured " + name + "!");
		return new SaveData{
			state = state,
		};
	}

	public virtual void RestoreState(object state){
		Debug.Log("Restored " + name + "!");
		SaveData saveData = (SaveData)state;
		this.state = saveData.state;
		SetState(saveData.state);
	}

	[Serializable]
	private struct SaveData{
		public bool state;
	}
}