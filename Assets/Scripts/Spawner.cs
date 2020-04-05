using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{


	public GameObject fallingBlockPrefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	private float nextSpawnTime;
	public static float spawnSize;
	private Vector2 screenHalfSizeWorldUnits;

	public Vector2 spawnSizeMinMax;

	public float spawnAngleMax;
	// Use this for initialization
	void Start ()
	{
		screenHalfSizeWorldUnits =
			new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextSpawnTime)
		{
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x,Difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);

			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject fallingBlock = (GameObject) Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
			

			fallingBlock.transform.localScale = Vector2.one * spawnSize;

			
		}
	}

	public static float GetSpawnSize()
	{
		return spawnSize;
	}



}
