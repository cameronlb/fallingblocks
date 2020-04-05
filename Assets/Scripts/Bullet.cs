using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 20f;

    private float screenHalfWidthInWorldUnits;
    private float screenHalfHeightInWorldUnits;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * Speed;
        
        float halfPlayerWidth = transform.localScale.x / 2f;
        float halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            Destroy(gameObject);

        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            Destroy(gameObject);

        }

        if (transform.position.y < -screenHalfHeightInWorldUnits)
        {
            Destroy(gameObject);

        }

        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            Destroy(gameObject);

        }
        
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {

        if (triggerCollider.tag == "Falling Block")
        {
            Destroy(gameObject);
        }
    }
}
