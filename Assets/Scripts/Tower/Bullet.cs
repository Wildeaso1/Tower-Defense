using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float Speed;

    public void Seek(Transform _target)
	{
        target = _target;
	}


    // Update is called once per frame
    void Update()
    {
        if (target == null)
		{
            Destroy(gameObject);
            return;
		}

		BulletMovement();

    }

    void BulletMovement()
	{
		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = Speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
	}

    void HitTarget()
	{
		Destroy(gameObject);
	}
}
