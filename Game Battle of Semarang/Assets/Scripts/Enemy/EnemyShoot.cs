﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public static EnemyShoot instance;

    public GameObject bullet;
    public Transform shootPoint;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ShootBullet()
    {
        Instantiate(bullet, shootPoint.position, transform.rotation);
        
    }
}
