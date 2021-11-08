using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamover : MonoBehaviour
{
	public Text RoundsText;

	private void OnEnable()
	{
		RoundsText.text = PlayerStats.Rounds.ToString();
	}

	public void Retry()
	{
		SceneManager.LoadScene(1);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
