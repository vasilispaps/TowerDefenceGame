
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 60f;

    public int damage = 50;

    public void seek(Transform target2)
    {
        target = target2;
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {


            if (target == null)
            {
                Destroy(gameObject);
                return;
            }
            if (target != null)
            {
                Vector3 dir = target.position - transform.position;
                float distanceThisFrame = speed * Time.deltaTime;

                if (dir.magnitude <= distanceThisFrame)
                {
                    HitTarget();
                    return;
                }

                transform.Translate(dir.normalized * distanceThisFrame, Space.World);
               // transform.LookAt(target);

            }
        }
        }

    void HitTarget()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        Damage(target);
        //Destroy(target.gameObject);
        Destroy(this.gameObject);
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }   
    }

}
