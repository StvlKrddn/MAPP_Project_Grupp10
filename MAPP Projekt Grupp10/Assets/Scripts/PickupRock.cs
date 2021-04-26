using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRock : MonoBehaviour
{
    private bool canPickUpRock = true;
    private PlayerState playerState;

    [SerializeField] private AudioClip playerRockPickupClip;
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
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                audioSource.PlayOneShot(playerRockPickupClip);
            }

        }
    }

}
