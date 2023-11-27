using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;  //nombre de tir par seconde
    private float fireCountdown = 0f;


    [Header("Use Laser")]
    public bool useLaser = false;
    public int damageOverTime = 30;
    public float slowAmount = .5f;  //0f fait aucun slow et 1f arrête completement la cible
    public LineRenderer lineRenderer;


    [Header("Unity Setup")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Transform firePoint;

   



    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f / WorldTime.getActionSpeed());
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy; 
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
                targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }else 
            {
                target = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if(useLaser == true)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            if(fireCountdown > 0f)
            {
                fireCountdown -= (Time.deltaTime * WorldTime.getActionSpeed());
            }

            return; 
        } 

        //Target lockOn
        LockOnTarget();

        if (useLaser)
        {
            Laser();
        } else 
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= (Time.deltaTime * WorldTime.getActionSpeed());

        }

        
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed * WorldTime.getActionSpeed()).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * WorldTime.getActionSpeed() * Time.deltaTime);
        targetEnemy.Slow(slowAmount);

        if(!lineRenderer.enabled) lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
