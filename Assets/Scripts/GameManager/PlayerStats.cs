using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static int Money;
	public int startMoney;

	public static int Health;
	public int StartHealth;
	public GameUI Healthbar;

	void Start()
	{
		Money = startMoney;
		Health = StartHealth;
		Healthbar.SetMaxHealth(StartHealth);
	}

	private void Update()
	{
		Healthbar.SetHealth(Health);
	}
}
