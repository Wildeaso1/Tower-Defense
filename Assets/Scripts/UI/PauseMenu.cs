using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseUI;
	public GameObject Shop;
	public GameObject Bars;


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) 
		{
			TogglePause();
		}
	}

	public void TogglePause()
	{
		PauseUI.SetActive(!PauseUI.activeSelf);
		Shop.SetActive(!Shop.activeSelf);
		Bars.SetActive(!Bars.activeSelf);

		if (PauseUI.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
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
