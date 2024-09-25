using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_to_home : MonoBehaviour
{
    public bool working = false;
    public GameObject gun;
    static int patroni;
    static int xp;
    static int gold;

    public void open()
    {
        working = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((working)&& (other.transform.gameObject.GetComponent<hp>() != null))
        {
            /* пересчет и сматываемся */
            patroni = gun.GetComponent<shot>().magazin + gun.GetComponent<shot>().ammo;
            xp = other.GetComponent<hp>().health;
            gold = other.GetComponent<hp>().gold;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
