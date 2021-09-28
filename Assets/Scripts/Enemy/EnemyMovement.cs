using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public float Speed = 10f;
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
			Destroy(gameObject);
			return;
		}

		waypointindex++;
		target = Waypoints.Waypoint[waypointindex];
	}
}
