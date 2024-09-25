using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switcher : MonoBehaviour
{
    public bool weapon = false;
    public GameObject main1;
    public GameObject main2;
    public bool can_switch = true;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _switch();
        }
    }
    public void _switch()
    {
        if (can_switch)
        {
            if (!weapon)
            {
                weapon = true;
                main1.SetActive(true);
                main2.gameObject.GetComponent<shot>().i_reload = false; 
                main1.gameObject.GetComponent<sword_script>().stance = 1;
                main2.SetActive(false);
            }
            else
            {
                weapon = false;
                main2.SetActive(true);
                main1.SetActive(false);
                main2.gameObject.GetComponent<shot>().i_reload = false;
            }
        }
    }
/*    void set_switch_on()
    {
        can_switch = true;
    }
    void set_switch_off()
    {
        can_switch = false;
    }*/

}
