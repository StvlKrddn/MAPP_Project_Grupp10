using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float fireRate = 1;
    private float nextFire;

    private void Start()
    {
        nextFire = Time.time;
    }

    private void Update()
    {
        checkIfTimeToFire();

    }

    private void checkIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
