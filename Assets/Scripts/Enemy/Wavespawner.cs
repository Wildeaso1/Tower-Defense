using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavespawner : MonoBehaviour
{
	public GameObject EnemyPrefab;

	[SerializeField] private float minSpeed;
	[SerializeField] private float maxSpeed;
	[SerializeField] private Transform Spawnpoint;
	[SerializeField] private float waveTime;
	[SerializeField] private float Countdown;

	private int waveIndex = 1;
	private float enemyInterval;

	private void Update()
	{
		if (Countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			Countdown = waveTime;

		}

		Countdown -= Time.deltaTime;
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;
		enemyInterval = Random.Range(0.0f, 3.0f);

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSecondsRealtime(enemyInterval);
		}

	}

	void SpawnEnemy()
	{
		GameObject NewEnemy = Instantiate(EnemyPrefab, Spawnpoint.position, Spawnpoint.rotation);
		NewEnemy.GetComponent<EnemyMovement>().Speed = Random.Range(minSpeed, maxSpeed);
	}
}
