
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5f;

    public float health = 100;

    public int value = 25;

    private bool isDead = false;

    //////movement ///////////////////////////////////


    private Transform target;
    private int wavepointi = 0;

    void Start()
    {
        target = waypoint.points[0];
    }

    

    void Update()
    {

        Vector3 direction = target.position - transform.position;
        direction.x = 1;

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            Nextwaypoint();
        }

        direction = target.transform.position - transform.position;
        this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),2*Time.deltaTime);
   

    }
    void Nextwaypoint()
    {
        if (wavepointi >= waypoint.points.Length - 1)
        {

            EndPath();
            return;

        }

        if (wavepointi < waypoint.points.Length - 1)
        {
            wavepointi++;
            target = waypoint.points[wavepointi];
        }
    }

    
    /// /////////////////////////////////////////////////////////
    
    public void TakeDamage(float amount)
    {
        if (gameObject != null)
        {
            health = health - amount;

            if (health <= 0 && !isDead)
            {
                Die();
            }
        }
        
    }

    void Die()
    {
        isDead = true;

        if (gameObject != null)
        {

            Player.Money += value;



            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
        }
    }

    void EndPath()
    {
        Player.Lives--;
        Destroy(gameObject);
    }
}
