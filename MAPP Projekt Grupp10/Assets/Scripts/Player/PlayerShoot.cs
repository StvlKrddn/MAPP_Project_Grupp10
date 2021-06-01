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
    private AudioSource audioSource;
    public List<AudioClip> audioClips;

    private void Start()
    {
        movement = gameObject.GetComponent<Scr_Movement>();
        playerState = gameObject.GetComponent<PlayerState>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

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
        if (timeUntilFire < Time.time && playerState.IsRockAvailable())
        {
            playerAnimator.SetTrigger("ThrowRock");
            playerState.ThrowRock();
            GameObject rock = Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 180f)));
            audioSource.PlayOneShot(audioClips[Random.Range(0,audioClips.Count)]);
            Destroy(rock, 1.2f);
            timeUntilFire = Time.time + fireRate;
        }
    }
}
