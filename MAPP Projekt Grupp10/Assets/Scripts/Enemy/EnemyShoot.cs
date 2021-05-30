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
        CheckIfTimeToFire();

    }

    private void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
