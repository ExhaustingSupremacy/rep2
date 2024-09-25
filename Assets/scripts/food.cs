using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    public int restore_hp = 25;

    void OnTriggerEnter(Collider other)
    {
        if ((other.transform.gameObject.GetComponent<hp>() != null) && (other.transform.gameObject.tag == "Player"))
        {
            Debug.Log("касаюсь игрока");
            int _resulthp = restore_hp + other.transform.gameObject.GetComponent<hp>().health;
            other.transform.gameObject.GetComponent<hp>()._text_health.text = "Здоровье" + _resulthp;
            other.transform.gameObject.GetComponent<hp>().health += restore_hp;
            Destroy(this.gameObject);
        }
    }
}
