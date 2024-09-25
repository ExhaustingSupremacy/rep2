using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public int zombies = 1;
    public float time;
    public void FixedUpdate()
    {
        time += 0.1f * Time.deltaTime;
        if (time >= 0.25f)
        {
            summon();
            time = 0;
        }
    }
    public void summon()
    {
            Debug.Log("ѕытаюсь призвать");
            Instantiate(prefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(prefab, transform.position, Quaternion.Euler(0f, 0f, 0f));
    }
}
