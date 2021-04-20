using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{

    [SerializeField] private int maxHealth = 4;
    [SerializeField] private int currentHealth = 4;
    [SerializeField] private Image firstHealthPoint;
    [SerializeField] private Image secondHealthPoint;
    [SerializeField] private Image thirdHealthPoint;
    [SerializeField] private Image forthHealthPoint;

    [SerializeField] private int bananasCollected = 0;


    // Start is called before the first frame update
    void Start()
    {
        resetHp();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void damagePlayer(int damage)
    {
        currentHealth = currentHealth - damage;
        updateHealthIcons();
        if (currentHealth < 0)
        {
            gameOver();
        }
    }

    public void healPlayer(int heal)
    {

        if (currentHealth < maxHealth)
        {
            if (currentHealth + heal > maxHealth)
            {
                resetHp();
            }
            else
            {
                currentHealth = currentHealth + heal;
                updateHealthIcons();
            }
        }
    }

    public void resetHp()
    {
        currentHealth = maxHealth;
        updateHealthIcons();
    }

    private void updateHealthIcons()
    {
        if (currentHealth == 4)
        {
            firstHealthPoint.enabled = true;
            secondHealthPoint.enabled = true;
            thirdHealthPoint.enabled = true;
            forthHealthPoint.enabled = true;
        }
        else if (currentHealth == 3)
        {
            firstHealthPoint.enabled = true;
            secondHealthPoint.enabled = true;
            thirdHealthPoint.enabled = true;
            forthHealthPoint.enabled = false;
        }
        else if (currentHealth == 2)
        {
            firstHealthPoint.enabled = true;
            secondHealthPoint.enabled = true;
            thirdHealthPoint.enabled = false;
            forthHealthPoint.enabled = false;
        }
        else if (currentHealth == 1)
        {
            firstHealthPoint.enabled = true;
            secondHealthPoint.enabled = false;
            thirdHealthPoint.enabled = false;
            forthHealthPoint.enabled = false;
        }
        else
        {

            firstHealthPoint.enabled = false;
            secondHealthPoint.enabled = false;
            thirdHealthPoint.enabled = false;
            forthHealthPoint.enabled = false;
        }
    }

    private void gameOver()
    {
        print("Game Over");

    }

    public void pickupBanana()
    {
        bananasCollected++;
    }

    public int getBanana()
    {
        return bananasCollected;
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }
}
