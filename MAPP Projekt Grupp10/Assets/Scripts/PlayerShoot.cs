using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject bulletPrefab;
    private float timeUntilFire;
    Scr_Movement movement; 


    private void Start(){
        movement = gameObject.GetComponent<Scr_Movement>();
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0) && timeUntilFire < Time.time){
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    private void Shoot(){
        GameObject rock = Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 180f))); 
        Destroy(rock, 5f);
    }
}
