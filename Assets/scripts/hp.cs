using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using System;

public class hp : MonoBehaviour
{
    public TextMeshProUGUI _text_health;
    public int health;
    public GameObject pref;
    public GameObject spawner;
    public GameObject player;
    public GameObject spawnn;
    public int gold = 200;
    public bool isDayNow = false;
    public GameObject counter;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnn = GameObject.FindWithTag("spawner");
    }
    public void low_health()
    {
        _text_health.text = "Здоровье " + health;
        health -= 1;
        if (health <= 0)
        {
            _text_health.text = "Вы проиграли";
            Time.timeScale = 0;
        }
    }
    public void grow_health()
    {
        health += 5;
        _text_health.text = "Здоровье " + health;
    }
    public void death(string type)
    {
        if (type == "ragdoll")
        {
            if (pref == null)
            {
                
            } else
            {
                /*transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);*/
                /*Destroy(transform.gameObject);
                Instantiate(pref, transform.position, Quaternion.Euler(90f, 0f, 0f));*/
                Destroy(transform.gameObject.GetComponent<movin>());
                Destroy(transform.gameObject.GetComponent<Animator>());
                transform.gameObject.GetComponent<lifetime>().enabled = true;
                transform.gameObject.GetComponent<Rigidbody>().freezeRotation = false;
                /*if (transform.gameObject.tag == "zomb")
                {

                    spawner.transform.gameObject.GetComponentInChildren<spawner>().summon();
                }*/
            }
            
        }
    }
}
