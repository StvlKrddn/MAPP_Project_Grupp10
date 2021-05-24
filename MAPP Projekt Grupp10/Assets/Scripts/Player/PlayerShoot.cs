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
    PlayerState playerState;


    private Animator playerAnimator;

    private void Start()
    {
        movement = gameObject.GetComponent<Scr_Movement>();
        playerState = gameObject.GetComponent<PlayerState>();
        playerAnimator = GetComponent<Animator>();

 
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (timeUntilFire < Time.time && playerState.isRockAvailable())
        {
            playerAnimator.SetTrigger("ThrowRock");
            playerState.throwRock();
            GameObject rock = Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 180f)));
            Destroy(rock, 1.2f);
            timeUntilFire = Time.time + fireRate;
        }
    }
}
