using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    public float timelife;
    void FixedUpdate()
    {
        timelife += 0.1f * Time.deltaTime;
        if (timelife >= 1f)
        {
            Destroy(transform.gameObject);
        }
    }
}
