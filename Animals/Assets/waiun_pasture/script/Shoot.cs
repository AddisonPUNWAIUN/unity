﻿using UnityEngine;
using System.Collections;
 
public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gun;

    private float time;

    private void Start()
    {
        time = 0;
    }
    void Update()
    {
        time++;
        if (time == 30)
        {
            shoot();
            time = 0;
        }
    }
    void shoot()
    {
        GameObject cloneBullet = Instantiate(bullet) as GameObject;
        cloneBullet.transform.position = gun.transform.position;
        Destroy(cloneBullet, 2);
    }
}