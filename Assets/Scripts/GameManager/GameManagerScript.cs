using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
	public static bool GameEnded = false;
	public GameObject GameOverUI;

	private void Start()
	{
		GameEnded = false;
	}

	private void Update()
	{
		if (GameEnded)
		{
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
		Debug.Log("The End");
		GameOverUI.SetActive(true);
	}

}
