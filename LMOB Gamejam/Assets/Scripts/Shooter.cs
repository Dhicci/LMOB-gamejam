﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool time_out;
    public GameObject bullet_prefab;
    public Transform fire_point;
    public float shoot_delay = 3.0f;
    float time_left;

    private void Start()
    {
        time_left = shoot_delay;
    }
    // Update is called once per frame
    void Update()
    {
        if (time_out == false)
        {
            time_left -= Time.deltaTime;
            if (time_left <= 0)
            {
                time_left = shoot_delay;
                Shoot();
            }
        }
        else
        {
            time_left = shoot_delay;
        }
        
    }

    public void Shoot()
    {
        Instantiate(bullet_prefab, fire_point.position, fire_point.rotation);
    }

}
