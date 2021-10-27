using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float Speed;
	public float Startspeed;

	[SerializeField] private int Worth;
	[SerializeField] private float Health;

	private void Start()
	{
		Startspeed = Speed;
	}

	public void TakeDamage(float amount)
	{
		Health -= amount;

		if (Health <= 0)
		{
			PlayerStats.Money += Worth;
			Die();
		}
	}

	public void Slow(float amount)
	{
		Speed = 1f - amount;
	}

	void Die()
	{
		Destroy(this.gameObject);
	}

}
