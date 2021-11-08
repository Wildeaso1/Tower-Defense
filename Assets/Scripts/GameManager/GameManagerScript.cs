using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	public static bool GameEnded = false;
	public GameObject GameOverUI;

	private void Start()
	{
		Time.timeScale = 1f;
		GameEnded = false;
	}

	private void Update()
	{
		if (GameEnded)
		{
			Time.timeScale = 0f;
			return;
		}

		if (PlayerStats.Health <= 0)
		{
			EndGame();
		}
	}

	void EndGame()
	{
		GameEnded = true;
		GameOverUI.SetActive(true);
	}

}
