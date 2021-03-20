﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Animator anim;
    public bool time_out;
    public GameObject bullet_prefab;
    private GameObject Bullet;
    public Transform fire_point;
    public float shoot_delay = 3.0f;
    float time_left;
    bool r = false;
    public float rewind_time;

    private void Start()
    {
        time_left = shoot_delay;
    }
    // Update is called once per frame
    void Update()
    {
        if (time_out == false)
        {
            r = false;
            time_left -= Time.deltaTime;
            if (time_left <= 0)
            {
                time_left = shoot_delay;
                Shoot();
            }
        }
        else
        {
            if (r == false)
            {
                time_left += rewind_time;
                if (time_left > shoot_delay)
                {
                    time_left = time_left - shoot_delay;
                    if (time_left > shoot_delay)
                    {
                        time_left = time_left - shoot_delay;
                        if (time_left > shoot_delay)
                        {
                            time_left = time_left - shoot_delay;
                            if (time_left > shoot_delay)
                            {
                                time_left = time_left - shoot_delay;

                            }
                        }
                    }
                }
                r = true;
            }
            
        }
        
    }

    public void Shoot()
    {
        gameObject.GetComponent<AudioSource>().Play();
        anim.SetTrigger("shoot");
        Bullet = Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
        Vector3 local_velocity = Vector3.ClampMagnitude(new Vector3(1, 0, 0), 1);
        Bullet.GetComponent<BulletMove>().BulletDirection(transform.right);
    }

}
