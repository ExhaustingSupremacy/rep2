using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class skeletonbehaivor : MonoBehaviour
{
    public float timer;
    public float speed;
    public float range;
    public float random = 150f;
    public GameObject look;
    public bool pause = false;
    public GameObject counter;
    void Update()
    {
        if (((look.transform.position - transform.position).magnitude) <= range)
        {
            active();
        }
        else
        {
            passive();
        } 
    }
    void active()
    {
        transform.LookAt(new Vector3(look.transform.position.x, transform.position.y, look.transform.position.z));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(look.transform.position.x, transform.position.y, look.transform.position.z), speed * Time.deltaTime);
    }

    void passive()
    {

        if ((timer <= 5) && (!pause))
        {
            timer += Time.deltaTime;
            this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Force);
        }
        if ((timer >= 5) || (pause))
        {
            pause = true;
            timer -= Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, random, 0f), Time.deltaTime); ;
        }
        if (timer < 0)
        {
            pause = false;
            random = UnityEngine.Random.Range(-200f, 200f);
            timer = 0;
        }
    }
    private void OnCollisionExit (Collision collision)
    {
        if (collision.gameObject.transform.GetComponent<hp>() != null)
        {
            collision.gameObject.transform.GetComponent<hp>().health -= 1;
            collision.gameObject.transform.GetComponent<hp>().low_health();
        }
    }
    public void death()
    {
        counter.transform.GetComponent<kill_stats>().add_kill();
        Destroy(transform.GetComponent<skeletonbehaivor>());
        transform.GetComponent<Rigidbody>().freezeRotation = false;
    }
}
