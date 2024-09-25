using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kill_stats : MonoBehaviour
{
    public int spirit_kills;
    public TextMeshProUGUI textik;
    public GameObject portal;
    public GameObject good;
    public void add_kill()
    {
        spirit_kills += 1;
        textik.text = "Убито призраков на сегодня: " + spirit_kills + "/10";
        if (spirit_kills >= 10)
        {
            win_celebration();
        }
    }
    void win_celebration()
    {
        good.transform.gameObject.SetActive(true);
        /* открытие портала домой и много еды ГОТОВО*/
        portal.GetComponent<portal_to_home>().working = true;
    }
}
