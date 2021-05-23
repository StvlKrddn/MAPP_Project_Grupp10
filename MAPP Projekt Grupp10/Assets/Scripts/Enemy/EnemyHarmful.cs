using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHarmful : MonoBehaviour
{

    [SerializeField] private int damage = 1;
    [SerializeField] private AudioClip playerDamageClip;
    private bool hasDamagedPlayer = false;
    private AudioSource audioSource;
    private Animator enemyAnimator;
    [SerializeField] private GameObject rockParticles;


    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        enemyAnimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasDamagedPlayer == false)
        {
            collision.gameObject.GetComponent<PlayerState>().damagePlayer(damage);
            hasDamagedPlayer = true;
            collision.GetComponent<PlayerState>().invinciblePlayer();
            audioSource.PlayOneShot(playerDamageClip);
            enemyAnimator.SetTrigger("IsDestroyed");
        }
        if (collision.gameObject.CompareTag("Rock") && hasDamagedPlayer == false)
        {
            hasDamagedPlayer = true;
            enemyAnimator.SetTrigger("IsDestroyed");
            if (rockParticles != null)

                Instantiate(rockParticles, new Vector3(collision.transform.position.x + 1f, collision.transform.position.y), rockParticles.transform.rotation);
        }
    }

}

