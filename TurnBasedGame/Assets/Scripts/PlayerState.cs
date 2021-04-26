using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerMaxHealth;
    [SerializeField] private int playerLevel;
    [SerializeField] private int playerDamage;
    [SerializeField] private int playerSpeed;
    [SerializeField] private int playerExperiance;

    [SerializeField] Button attackButton;

    private bool playerTurn;

    private EnemyState enemyState;

    private void Start()
    {

        enemyState = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyState>();


        if (playerSpeed >= enemyState.getEnemySpeed())
        {
            playerTurn = true;
        }
        else
        {
            playerTurn = false;
        }

    }

    private void Update()
    {
        if (playerTurn == false)
            attackButton.interactable = false;
        else attackButton.interactable = true;
    }


    public void takeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        if (playerHealth < 0)
        {
            gameOver();
        }
    }

    public void heal(int heal)
    {
        if (playerHealth + heal <= playerMaxHealth)
            playerHealth = playerHealth + heal;
        else playerHealth = playerMaxHealth;
    }

    private void gameOver()
    {
        print("Game Over");
    }

    public void damageEnemy()
    {
        enemyState.takeDamage(playerDamage);
    }

    public void endTurn()
    {
        playerTurn = false;
        enemyState.makeAction();
    }

    public void startTurn()
    {
        playerTurn = true;
        attackButton.interactable = true;
    }

    public bool isPlayerTurn()
    {
        return playerTurn;
    }

}
