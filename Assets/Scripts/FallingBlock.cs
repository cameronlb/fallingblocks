using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
	public Vector2 speedMinMax;
	private float speed;
	private float health = Spawner.GetSpawnSize();

	private float visibleHeightThreshold;


	public Rigidbody2D rb;
	// Use this for initialization
	void Start ()
	{
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

		visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.down * speed * Time.deltaTime);
		if (health <= 0)
		{
			print(health);
			Destroy(gameObject);
		}

		if (transform.position.y < visibleHeightThreshold)
		{
			Destroy(gameObject);
		}

		{
			
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet")
		{
			health -= 0.1f;
			print(health);
		}

		{
			
		}
	}
}
