using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    private float attackSpeed = 10f;
    public float damage = 0.1f;
    public GameObject bulletPrefab;
    private Boolean shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0f, 1f / attackSpeed);

    }

    // Update is called once per frame
    void Update()
    {
        shooting = false;
        if (Input.GetButton("Fire1"))
        {
            shooting = true;
        }

        
    }

    void Shoot()
    {
        if (!shooting) return;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        

    }
}
