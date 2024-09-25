using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class new_scene_check : MonoBehaviour
{
    public GameObject infoObject;
    public GameObject panel;
    public GameObject gun;
    public Animator anima_controller;
    public bool is_now_day;
    public GameObject true_light;
    static int gold;
    static int ammo;
    static int health;

    private void Start()
    {
        anima_controller = panel.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.transform.gameObject.tag == "Player"))
        {
            gold = infoObject.GetComponent<hp>().gold;
            ammo = gun.GetComponent<shot>().ammo + gun.GetComponent<shot>().magazin;
            health = infoObject.GetComponent<hp>().health;
            Debug.Log("голд " + gold + " пули " + ammo + " здоровья"+ health);
            anima_controller.SetTrigger("i_go");
            true_light.transform.GetComponent<Light>().color = Color.white;
            SceneManager.LoadScene("kingdom");
        }
    }
}
