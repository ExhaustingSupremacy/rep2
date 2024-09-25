using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouselook : MonoBehaviour
{
    public CharacterController controller;
    public Transform player_root;
    public float speed;
    public static bool isgrounded;
    Vector3 velocity;
    public float gravity;
    public LayerMask WhatIsGround;
    public Transform groundcheck;
    public float groundCheckDistance;
    public float previousx;
    public float previousy;
    float _speedkoof = 1;
    CharacterController rb;
    private void Start()
    {
        rb = GetComponent<CharacterController>();
    }
    private void Update()
    {

        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speedkoof = 0.5f;
        }
        else
        {
            _speedkoof = 1f;
        };
        Vector3 move = player_root.forward * y + player_root.right * x;
        controller.Move(move *speed*_speedkoof *Time.deltaTime);
        previousx = x; previousy = y;

        /*RaycastHit groundhit;*/
        /*isgrounded = Physics.Raycast(groundcheck.position, groundcheck.TransformDirection(Vector3.down), out groundhit, groundCheckDistance, WhatIsGround);*/
        isgrounded = Physics.CheckSphere(groundcheck.position, groundCheckDistance, WhatIsGround);
        if (!isgrounded)
        {
            velocity.y += -20f*Time.deltaTime;
        }
        else
        {
/*            velocity.y = 0f;*/
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = 150f * Time.deltaTime;
/*                rb.AddForce(transform.up * 100f);*/
            }
        }
        controller.Move(velocity* Time.deltaTime);
    }
}
