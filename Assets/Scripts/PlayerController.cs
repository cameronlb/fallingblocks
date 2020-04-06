using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 7;
    Vector2 movement = new Vector2();


    public event System.Action OnPlayerDeath;
    
    private Rigidbody2D rb2d;

    private float screenHalfWidthInWorldUnits;
    private float screenHalfHeightInWorldUnits;


    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        float halfPlayerHeight = transform.localScale.y / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        screenHalfHeightInWorldUnits = Camera.main.orthographicSize - halfPlayerHeight;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Boundaries();
    }

    private void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(inputX, (inputY * 1.2f));
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

    void Boundaries()
    {
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
            rb2d.velocity = new Vector2(0, 0);
        }

        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
            rb2d.velocity = new Vector2(0, 0);
        }

        if (transform.position.y < -screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, -screenHalfHeightInWorldUnits);
            rb2d.velocity = new Vector2(0, 0);
        }

        if (transform.position.y > screenHalfHeightInWorldUnits)
        {
            transform.position = new Vector2(transform.position.x, screenHalfHeightInWorldUnits);
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}

