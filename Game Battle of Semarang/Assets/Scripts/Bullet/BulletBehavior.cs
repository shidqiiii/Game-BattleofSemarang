﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed, damage, destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Tilemap")) || (collision.CompareTag("Enemy")))
        {
            Destroy(gameObject);
        }
    }
}
