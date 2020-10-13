using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    public int damage;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        Health health = collision.transform.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
