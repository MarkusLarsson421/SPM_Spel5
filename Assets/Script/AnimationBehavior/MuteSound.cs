using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteSound : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("SM").GetComponent<SoundManager>().MuteSource("subtitles");
    }
}
