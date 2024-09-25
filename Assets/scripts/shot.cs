using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using Unity.VisualScripting;

public class shot : MonoBehaviour
{
    public GameObject target;
    public GameObject spawner;
    public AudioClip sfx;
    public AudioSource _audiosource;
    public Camera _cam;
    public GameObject fire;
    private bool i_shooted = false;
    private Animator _anime;
    public int ammo = 30;
    public TextMeshProUGUI _textMeshProUGUI;
    public bool i_reload = false;
    public GameObject player_obj;
    public int magazin = 6;

    private void Start()
    {
        _anime = GetComponent<Animator>();
        
    }
    public void Update()
    {
        if (i_shooted)
        {
            i_shooted = false;
            fire.transform.gameObject.SetActive(false);
        };
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (magazin > 0)
            {
                shoot();
            }
            
        }
        if ((Input.GetKeyDown(KeyCode.R)))
        {
            _anime.SetBool("reloading", true);
            i_reload = true;
            int a = 6 - magazin;
            if (ammo == 0) { } else if ((ammo-a) < 0) { ammo = 0;} else if (ammo - a > 0) { magazin += a;ammo -= a; } 
            
            _textMeshProUGUI.text = "Патроны: " + ammo + "/" + magazin;
        }
    }
    void shoot()
    {
        if (i_reload == true)
        {

        }
        else
        {

        
        AudioSource.PlayClipAtPoint(sfx, transform.position);
        fire.transform.gameObject.SetActive(true);
        i_shooted = true;
        magazin -= 1;
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward,out hit,200f))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * 1220);
                if (hit.transform.gameObject.GetComponentInChildren<hp>() != null)
                {
                    hit.transform.gameObject.GetComponentInChildren<hp>().health -= 1;
                    if (hit.transform.gameObject.GetComponentInChildren<hp>().health <= 0)
                    {
                        if (hit.transform.gameObject.tag == "zomb")
                            {
                                target.GetComponentInChildren<hp>().grow_health();
                                spawner.transform.gameObject.GetComponentInChildren<spawner>().summon();
                            }
/*                        Destroy(hit.transform.gameObject);*/
/*                        ammo += 5;*/
                            /* скрипт перезарядки*/
                        /*_anime.SetBool("reloading", true);
                        i_reload = true;*/
                            /**/
                    }
                }
                if (hit.transform.gameObject.GetComponent<skeletonbehaivor>() != null)
                    {
                        hit.transform.gameObject.GetComponent<skeletonbehaivor>().death();
                        /*player_obj.transform.GetComponent<hp>().counter.GetComponent<quest>().statsup();*/
                    }
                
            }
                if (hit.transform.gameObject.tag == "candle")
                {
                    /*Destroy(hit.transform.gameObject);
                    Destroy(hit.transform.gameObject.GetComponent<hp>().pref);*/
                    hit.transform.gameObject.SetActive(false);
                    hit.transform.gameObject.GetComponent<hp>().pref.SetActive(false);
                }
        }
        _textMeshProUGUI.text = "Патроны: " + ammo + "/" + magazin;
        }
    }
    void endreload()
    {
            _anime.SetBool("reloading", false);
            i_reload = false;
        
    }
    void switch_on()
    {
        Debug.Log("свитч он");
        player_obj.GetComponent<switcher>().can_switch = true;
    }
    void switch_off()
    {
        Debug.Log("свитч офф");
        player_obj.GetComponent<switcher>().can_switch = false;
    }
}
