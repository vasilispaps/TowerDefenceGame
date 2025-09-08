using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    private Enemy targetEnemy;


    public float range = 15f;

    public int cost = 100;

    public float fireRate = 1f;
    private float fireCountdown = 0f;


    public GameObject bulletPrefab;
    public Transform firePoint;


    public bool useLaser = false;
    public LineRenderer lineRenderer;
    public int damageOverTime = 30;

    public string enemyTag = "Enemy";
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
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range) {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (useLaser == true)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }

            return;
        }

       


        if (useLaser == true)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.seek(target);
    }
void Laser()
{
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);


        if (!lineRenderer.enabled)
        lineRenderer.enabled = true;

    lineRenderer.SetPosition(0, firePoint.position);
    lineRenderer.SetPosition(1, target.position);
}


void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
