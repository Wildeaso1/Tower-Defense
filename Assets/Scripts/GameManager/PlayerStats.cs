using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[Header("Money")]
	public static int Money;
	public int startMoney;

	[Header("Rounds")]
	public static int Rounds;

	[Header("Health")]
	public static int Health;
	public int StartHealth;
	public GameUI Healthbar;

	void Start()
	{
		Money = startMoney;
		Health = StartHealth;
		Healthbar.SetMaxHealth(StartHealth);
		Rounds = 0;
	}

	private void Update()
	{
		Healthbar.SetHealth(Health);
	}
}
