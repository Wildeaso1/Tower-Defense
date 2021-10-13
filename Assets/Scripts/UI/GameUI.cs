using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameUI : MonoBehaviour
{

	public Text MoneyText;
	public Slider HealthSlider;
	[SerializeField] private float SlideTime;

	private void Update()
	{
		MoneyText.text = "$" + PlayerStats.Money.ToString();
	}

	public void SetMaxHealth(int health)
	{
		HealthSlider.maxValue = health;
		HealthSlider.value = health;
	}

	public void SetHealth(int health)
	{
		HealthSlider.DOValue(health, SlideTime);
	}
}
