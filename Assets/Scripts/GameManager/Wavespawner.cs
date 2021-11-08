using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour
{
	public GameObject EnemyPrefab;

	[Header("Wave Setup")]
	[SerializeField] private float minSpeed;
	[SerializeField] private float maxSpeed;
	[SerializeField] private Transform Spawnpoint;
	[SerializeField] private float waveTime;
	[SerializeField] private float Countdown;
	[SerializeField] private Text Wavetext;

	private int waveIndex = 0;
	private float enemyInterval;

	private void Update()
	{
		if (Countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			Countdown = waveTime;

		}

		Countdown -= Time.deltaTime;

		Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);

		Wavetext.text = string.Format("{0:00:00}", Countdown);
		
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;
		PlayerStats.Rounds++;
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
		NewEnemy.GetComponent<Enemy>().Speed = Random.Range(minSpeed, maxSpeed);
	}
}
