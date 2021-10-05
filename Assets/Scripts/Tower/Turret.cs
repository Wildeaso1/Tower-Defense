using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("Enemy Setup")]
    [SerializeField] private Transform target;
    [SerializeField] private float range = 15f;
    [SerializeField] private Transform Rotatepart;
    [SerializeField] private float turnSpeed = 10f;
    public string enemyTag = "Enemy";

    [Header("Shooting Setup")]
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform BulletSpawn;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

			if (distanceToEnemy < shortestDistance)
			{
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
            target = nearestEnemy.transform;
		}
		else
		{
            target = null;
		}
	}

    // Update is called once per frame
    void Update()
    {
        if (target == null)
		{
            return;
		}

        LookAtEnemy();

    }

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
	}

    void Shoot()
	{

        if (target == null)
		{
            return;
		}
        GameObject BulletGo = (GameObject)Instantiate(BulletPrefab, BulletSpawn.position, BulletSpawn.rotation);
        Bullet bullet = BulletGo.GetComponent<Bullet>();

		if (bullet != null)
		{
            bullet.Seek(target);
		}
	}

    void LookAtEnemy()
	{
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(Rotatepart.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Rotatepart.rotation = Quaternion.Euler(-90f, rotation.y, 53f);
    }
}
