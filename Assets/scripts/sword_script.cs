using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sword_script : MonoBehaviour
{
    public GameObject _dragonslayer;
    private Animator _animator;
    public int stance = 1;
    public GameObject player;
    public GameObject gun;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (stance == 1)
            {
                setstance(2);
                _animator.SetTrigger("slash1");
            }
            if (stance == 3)
            {
                setstance(4);
                _animator.SetTrigger("slash2");
            }
        }
    }
    public void setstance(int a)
    {
        stance = a;
    }
    public void damage()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _dragonslayer.transform.right, out hit, 5.5f))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 1220);
                if (hit.transform.gameObject.GetComponent<skeletonbehaivor>() != null)
                {
                    /*Destroy(hit.transform.gameObject);*/
                    /*hit.transform.gameObject.GetComponent<hp>().health -= 1;
                    if (hit.transform.gameObject.GetComponent<hp>().health <= 0)
                    {
                        *//*Destroy(hit.transform.gameObject);*//*
                        hit.rigidbody.AddForce(-hit.normal * 1220);
                    }
                    hit.transform.gameObject.GetComponent<hp>().death("ragdoll");
                    player.transform.gameObject.GetComponent<hp>().grow_health();
                    gun.transform.gameObject.GetComponent<shot>().ammo += 5;*/
                    hit.transform.gameObject.GetComponent<skeletonbehaivor>().death();
                };
            }
            
        }
    }
}
