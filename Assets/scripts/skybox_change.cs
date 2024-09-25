using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skybox_change : MonoBehaviour
{
    public Material skbx_day;
    public Material skbx_night;
    public bool skbx_is_day = false;
    public GameObject player_gameogj;
    void change_skybox()
    {
        if (!skbx_is_day)
        {
            RenderSettings.skybox = skbx_day;
            player_gameogj.transform.gameObject.GetComponent<hp>().isDayNow = true;
        }
        
    }
}
