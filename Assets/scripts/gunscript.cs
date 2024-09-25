using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
    private Animator _anim;
    public float previous_frame;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }


    void Update()
    {
        
        if (((Mathf.Abs(Input.GetAxis("Vertical")))!= 0) && (mouselook.isgrounded))
        {
            _anim.SetBool("running", true);
        }
        
        else
        {
            _anim.SetBool("running", false);
        }
        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            _anim.SetTrigger("shot");
        }
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            _anim.SetBool("leftright", true);
            Debug.Log("левоправо");
        }
        else
        {
            _anim.SetBool("leftright", false);
        }
    }
}
