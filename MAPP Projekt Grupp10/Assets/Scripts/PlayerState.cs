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

    [SerializeField] private int amountOfRocksAvailable = 0;
    [SerializeField] private int maxAmountOfRocksAvailable = 3;

    private bool isFading = false;
    private bool isFadingBack = false;

    private Color color;
    private Color originalColor;


    // Start is called before the first frame update
    void Start()
    {
        resetHp();
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        checkForFade();
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

    public int getAmountOfRocksAvailable()
    {
        return amountOfRocksAvailable;
    }

    public int getMaxAmountOfRocksAvailable()
    {
        return maxAmountOfRocksAvailable;
    }

    public void pickupRock()
    {
        if (amountOfRocksAvailable < maxAmountOfRocksAvailable)
        {
            amountOfRocksAvailable++;
        }
    }

    public void throwRock()
    {
        amountOfRocksAvailable--;
    }

    public bool isRockAvailable()
    {
        if (amountOfRocksAvailable < 0)
        {
            return true;
        }
        else return false;
    }

    public void invinciblePlayer()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        isFading = true;
    }

    private void checkForFade()
    {
        if (isFading == true)
        {
            color = gameObject.GetComponent<SpriteRenderer>().color;
            if (color.a > 0.3)
            {
                color.a = color.a - 0.03f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }

        if (color.a < 0.3)
        {
            isFadingBack = true;
            isFading = false;
        }

        if (isFadingBack == true)
        {
            color = gameObject.GetComponent<SpriteRenderer>().color;
            if (color.a < 1)
            {
                color.a = color.a + 0.03f;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
            else if (color.a >= 1)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                isFadingBack = false;
            }
        }
    }

}
