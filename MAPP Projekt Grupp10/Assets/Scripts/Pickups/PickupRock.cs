using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRock : MonoBehaviour
{
    private bool canPickUpRock = true;
    private PlayerState playerState;

    [SerializeField] private AudioClip playerRockPickupClip;
    [SerializeField] private ParticleSystem rockParticles;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true && canPickUpRock == true)
        {
            playerState = collision.GetComponent<PlayerState>();
            if (playerState.getAmountOfRocksAvailable() < playerState.getMaxAmountOfRocksAvailable())
            {
                playerState.pickupRock();
                canPickUpRock = false;
                Instantiate(rockParticles, transform.position, rockParticles.transform.rotation);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                FindObjectOfType<AudioManager>().Play("PickupRock");
            }

        }
    }

}
