using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using Unity.VisualScripting;

public class thing : MonoBehaviour
{
    public string whatido;
    public GameObject _gameobject1;
    public TextMeshProUGUI _tmp;
    public GameObject panel;

    public Animator _anima;
    public void Do(GameObject gmj, GameObject gun)
    {
        _gameobject1 = gmj;
        if ((whatido == "craft_table") && (_gameobject1.transform.gameObject.GetComponent<hp>().gold >= 0)) /* playsound smth*/
        {
            gun.transform.gameObject.GetComponent<shot>().ammo += 5;
            _gameobject1.transform.gameObject.GetComponent<hp>().gold -= 1;
            _tmp.text = "Патроны: " + gun.transform.gameObject.GetComponent<shot>().ammo + "/" + gun.transform.gameObject.GetComponent<shot>().magazin;
        }
        if (whatido == "bed")
        {
            _anima = panel.transform.gameObject.GetComponent<Animator>();
            _anima.SetTrigger("sleep_time");
        }
        if (whatido == "take_quest")
        {

        }
        if (whatido == "by_beer")
        {

        }
    }

}
