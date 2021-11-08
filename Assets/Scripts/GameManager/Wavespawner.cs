using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour
{
	public GameObject EnemyPrefab;

	private Enemy enemy;

	[Header("Wave Setup")]
	[SerializeField] private Transform Spawnpoint;
	[SerializeField] private float waveTime;
	[SerializeField] private float Countdown;
	[SerializeField] private Text Wavetext;
	[SerializeField] private Text RoundText;
	private bool AllEnemiesDead = false;

	[Header("Plus Round")]
	[SerializeField] private int SpeedPlus;
	[SerializeField] private int HealthPlus;
	[SerializeField] private int DamagePlus;

	[Header("Randomizers")]
	[SerializeField] private float minHealth;
	[SerializeField] private float maxHealth;
	[SerializeField] private float minSpeed;
	[SerializeField] private float maxSpeed;
	[SerializeField] private int MinDamage;
	[SerializeField] private int MaxDamage;
	[SerializeField] private float minInterval;
	[SerializeField] private float maxInterval;

	[HideInInspector]
	public int waveIndex = 0;
	private float enemyInterval;


	void Start()
	{


		switch (waveIndex)
		{
			case 5:
				maxSpeed += 1;
				maxHealth += 1;
				MaxDamage += 1;
				Countdown += 10;
				enemy.Worth += 5;

				break;
			case 10:
				maxSpeed += SpeedPlus;
				maxHealth += HealthPlus;
				MaxDamage += DamagePlus;
				Countdown += 10;
				enemy.Worth += 5;

				break;
			case 20:
				maxSpeed += SpeedPlus;
				maxHealth += HealthPlus;
				MaxDamage += DamagePlus;
				Countdown += 10;
				enemy.Worth += 5;
				break;
			default:
				break;
		}
	}
	public void Update()
	{
		if (Countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			Countdown = waveTime;
		}


		Counting();

		RoundText.text = PlayerStats.Rounds.ToString();

	}

	IEnumerator SpawnWave()
	{
		waveIndex++;
		PlayerStats.Rounds++;
		enemyInterval = Random.Range(minInterval, maxInterval);

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSecondsRealtime(enemyInterval);
		}

	}

	void SpawnEnemy()
	{
		GameObject NewEnemy = Instantiate(EnemyPrefab, Spawnpoint.position, Spawnpoint.rotation);
		NewEnemy.GetComponent<Enemy>().damage = Random.Range(MinDamage, MaxDamage);
		NewEnemy.GetComponent<Enemy>().Health = Random.Range(minHealth, maxHealth);
		NewEnemy.GetComponent<Enemy>().Speed = Random.Range(minSpeed, maxSpeed);
	}
	
	void Counting()
	{
		Countdown -= Time.deltaTime;

		Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);

		Wavetext.text = string.Format("{0:00:00}", Countdown);
	}
}
