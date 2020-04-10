using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    private float attackSpeed = 10f;
    public float damage = 0.1f;
    public GameObject bulletPrefab;
    private Boolean shooting = false;
    
    public Joystick joystickFire;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 1f / attackSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = joystickFire.Horizontal;
        float inputY = joystickFire.Vertical;
        
        if (inputX != 0.0 || inputY != 0.0)
        {
            float angle = Mathf.Atan2(inputY, inputX) * Mathf.Rad2Deg;
            firePoint.transform.rotation = Quaternion.AngleAxis((float) (angle - 90), Vector3.forward);
        }
        
        shooting = false;
        // if (Input.GetButton("Fire1"))
        if (joystickFire.Horizontal > 0 || joystickFire.Vertical > 0)
        {
            shooting = true;
        }

        
    }

    void Shoot()
    {
        if (!shooting) return;
        //Quaternion.LookRotation(-joystickFire.Direction)
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        

    }
}
