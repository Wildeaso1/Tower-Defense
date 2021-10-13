using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float Speed = 10f;

	[SerializeField] private int health;
	private Transform target;
	private int waypointindex = 0;
	[SerializeField] private float threshold;


	private void Start()
	{
		target = Waypoints.Waypoint[0];
	}

	private void Update()
	{
		Moveto();
	}

	void Moveto()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= threshold)
		{
			GetNextWayPoint();
		}
	}

	void GetNextWayPoint()
	{
		if (waypointindex >= Waypoints.Waypoint.Length - 1)
		{
			EndPath();
			return;
		}

		waypointindex++;
		target = Waypoints.Waypoint[waypointindex];
	}

	public void TakeDamage(int amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(this.gameObject);
	}

	void EndPath()
	{
		Destroy(gameObject);
		PlayerStats.Health--;
	}
}
