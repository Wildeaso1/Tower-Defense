using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private float Threshold;
	[SerializeField] 
	private int waypointindex = 0;
	private Transform target;
	private Enemy enemy;

	private void Start()
	{
		enemy = GetComponent<Enemy>();

		target = Waypoints.Waypoint[0];
	}

	private void Update()
	{
		Moveto();
		enemy.Speed = enemy.Startspeed;
	}

	void Moveto()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.Speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= Threshold)
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
	void EndPath()
	{
		Destroy(gameObject);
		PlayerStats.Health -= enemy.damage;

	}
}
