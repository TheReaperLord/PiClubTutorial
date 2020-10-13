using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
    public float range;
    public int damage;

    public ParticleSystem muzzleFlash;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Health health = hit.transform.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
