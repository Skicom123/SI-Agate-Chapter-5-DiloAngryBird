using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{
    Collider2D[] inExplosionRadius = null;
    [SerializeField] private float ExplosionForceMulti = 5;
    [SerializeField] private float ExplosionRadius = 5;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "Wood" || other.name == "Enemy")
        {
            Explode();
        }
    }
    
    void Explode()
    {
        inExplosionRadius = Physics2D.OverlapCircleAll(transform.position,ExplosionRadius);

        foreach (Collider2D o in inExplosionRadius)
        {
            Rigidbody2D o_rigidbody = o.GetComponent<Rigidbody2D>();
            if (o_rigidbody != null)
            {
                Vector2 distanceVector = o.transform.position - transform.position;
                if (distanceVector.magnitude > 0)
                {
                    float ExplosionForce = ExplosionForceMulti / distanceVector.magnitude;
                    o_rigidbody.AddForce(distanceVector.normalized * ExplosionForce);
                }

            }
        }

    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
