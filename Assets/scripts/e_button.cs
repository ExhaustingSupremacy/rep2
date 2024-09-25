using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_button : MonoBehaviour
{
    public Camera _cam;
    public GameObject gun_obj;
    void Update()
    {
        press_e_check();
    }
    void press_e_check()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, 80f))
            {
                if (hit.transform.gameObject.GetComponent<thing>() != null)
                {
                    hit.transform.gameObject.GetComponent<thing>().Do(this.gameObject, gun_obj);
                }
            }
            Debug.Log("Е нажата");
        }
    }
}
