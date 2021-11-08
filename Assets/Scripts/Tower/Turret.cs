using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    [Header("Enemy Setup")]
    [SerializeField] private Transform target;
    [SerializeField] private Transform Rotatepart;
    [SerializeField] private float turnSpeed = 10f;
    private Enemy targetEnemy;
    public string enemyTag = "Enemy";

    [Header("Shooting Setup (General)")]
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float range = 15f;

    [Header("Beam Setup")]
    [SerializeField] private bool UsingBeam = false;
    [SerializeField] private float DamageOverTime;
    [SerializeField] private float slowAmount;
    public LineRenderer lineRenderer;
    private bool ShootingBeam = false;

    [Header("Animation Setup")]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = false;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        anim = GetComponent<Animator>();
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
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
            anim.SetBool("Kamehameha", true);
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
			if (UsingBeam)
			{
				if (lineRenderer.enabled)
				{
                    DisableKamehameha();
                    lineRenderer.enabled = false;
				}
			}

            DisableKamehameha();
            anim.SetBool("Kamehameha", false);
            return;
		}

        LookAtEnemy();

		if (ShootingBeam)
		{
            ShootingKamehameha();
		}
		else
		{
            return;
		}

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
        
        GameObject BulletGo = (GameObject)Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
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

    void ShootingKamehameha()
	{
        targetEnemy.TakeDamage(DamageOverTime * Time.deltaTime);

        targetEnemy.Slow(slowAmount);

        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void UseKamehameha()
	{
        anim.speed = 0;
        ShootingBeam = true;
    }

    void DisableKamehameha()
	{
        ShootingBeam = false;
        anim.speed = 1;
        lineRenderer.enabled = false;
	}
}
