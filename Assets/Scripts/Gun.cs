using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private bool canShoot = true;

    void Shoot()
    {
        canShoot = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red, 10);

                hit.collider.GetComponent<Enemy>().TakeDamage();
            }
        }

        Invoke("RechargeShoot", 1);
    }

    void RechargeShoot()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }
}
