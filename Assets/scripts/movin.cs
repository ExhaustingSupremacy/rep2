using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movin : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public Transform spawnercall;
    public GameObject spawnn;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        spawnn = GameObject.FindWithTag("spawner");
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
        transform.LookAt(target.transform.position);

    }
    private void OnCollisionEnter(Collision victim)
    {
        if (victim.gameObject == null)
        {

        }
        else
        {
            if (victim.gameObject.tag == "Player")
            {
                Debug.Log("spawner is"+ spawnn.transform.gameObject.name);
                victim.gameObject.GetComponentInChildren<hp>().low_health();
            }
        }
    }
    
}
