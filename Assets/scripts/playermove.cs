using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Transform cam;
    public Transform player_rotation;
    public float senset;

    float rotationx;
    float rotationy;

    float clampx = 1f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        float x = Input.GetAxis("Mouse X") * clampx*Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * clampx * Time.deltaTime;
        clampx = Mathf.Clamp(clampx, 5f, 40f);
        
        if ((x==0) && (y == 0))
        {
            clampx = 5f;
            
        }
        if (clampx == 40f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                clampx -= 25f;
            }
            clampx -= 12f;
        }
        clampx += senset;
        rotationx -= y;
        rotationy += x;
        rotationx = Mathf.Clamp(rotationx,-75f,90f);

        player_rotation.rotation = Quaternion.Euler(0f, rotationy, 0f);
        cam.rotation = Quaternion.Euler(rotationx, rotationy, 0f);
        
    }
}
