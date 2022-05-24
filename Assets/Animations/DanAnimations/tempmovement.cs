using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempmovement : MonoBehaviour
{

    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float speed = Input.GetAxis("Horizontal");
        float direction = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", speed);
        anim.SetFloat("Direction", direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("PistolWhip");
        }
    }



}
