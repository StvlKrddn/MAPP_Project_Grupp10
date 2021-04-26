using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyMaxHealth;
    [SerializeField] private int enemyLevel;
    [SerializeField] private int enemyDamage;
    [SerializeField] private int enemySpeed;
    [SerializeField] private int enemyExperiance;

    private double timer;

    private PlayerState playerState;

    private void Start()
    {
        playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
    }

    private void Update()
    {
        if (playerState.isPlayerTurn() == false)
        {
            damagePlayer();
            playerState.startTurn();
        }

        timer += Time.deltaTime;


    }


    public void takeDamage(int damage)
    {
        enemyHealth = enemyHealth - damage;
        if (enemyHealth < 0)
        {
            endCombat();
        }
    }

    public void heal(int heal)
    {
        if (enemyHealth + heal <= enemyMaxHealth)
            enemyHealth = enemyHealth + heal;
        else enemyHealth = enemyMaxHealth;
    }

    public void endCombat()
    {
        print("Combat Over");
    }

    public void damagePlayer()
    {
        playerState.takeDamage(enemyDamage);
    }

    public void makeAction()
    {
        damagePlayer();
        playerState.startTurn();
    }

    public int getEnemySpeed()
    {
        return enemySpeed;
    }


}
