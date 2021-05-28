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
            hasDamagedPlayer = true;
            collision.gameObject.GetComponent<PlayerState>().damagePlayer(damage);
            collision.GetComponent<PlayerState>().invinciblePlayer();
            audioSource.PlayOneShot(playerDamageClip);
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("IsDestroyed");
            }
            
        }
        if (collision.gameObject.CompareTag("Rock") && hasDamagedPlayer == false)
        {
            FindObjectOfType<AudioManager>().Play("EnemyHurt");
            hasDamagedPlayer = true;
            if (enemyAnimator != null)
            {
                enemyAnimator.SetTrigger("IsDestroyed");
            }
            if (rockParticles != null)

                Instantiate(rockParticles, new Vector3(collision.transform.position.x + 1f, collision.transform.position.y), rockParticles.transform.rotation);
        }
    }

}

