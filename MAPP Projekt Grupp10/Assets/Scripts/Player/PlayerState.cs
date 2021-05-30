using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{

    [SerializeField] private int maxHealth = 4;
    [SerializeField] private int currentHealth = 4;
    private bool canTakeDamage = true;

    [SerializeField] private Image firstHealthPoint;
    [SerializeField] private Image secondHealthPoint;
    [SerializeField] private Image thirdHealthPoint;
    [SerializeField] private Image forthHealthPoint;

    [SerializeField] private int bananasCollected = 0;

    [SerializeField] private int amountOfRocksAvailable = 0;
    [SerializeField] private int maxAmountOfRocksAvailable = 3;

    private int gamesLost;

    private bool isFading = false;
    private bool isFadingBack = false;
    public bool isGameActive;
    public bool isTutorialEnabled;

    private Color color;
    private Color originalColor;

    [SerializeField] private int levelToLoad = 0;

    private LevelLoader levelLoader;

    //    [SerializeField] private string levelToLoad = "GameOverScene";

    public bool resetPlayerPrefs;

    private Animator playerAnimator;
    public GameObject tutorialCanvas;


    [SerializeField] List<AudioClip> hurtPlayerAudioClips;

    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;

        playerAnimator = GetComponent<Animator>();

        ResetHp();
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;

        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();

        if (resetPlayerPrefs == true)
        {
            ResetPlayerPrefs();
        }

        /* if (gamesLost == 0 || isTutorialEnabled == true)
         {
             tutorialCanvas.SetActive(true);
             tutorialCanvas.GetComponent<UiTutorial>().StartTutorial();
         }*/

        if (isTutorialEnabled == true || PlayerPrefs.GetInt("FirstTimePlaying") == 0)
        {
            tutorialCanvas.SetActive(true);
            tutorialCanvas.GetComponent<UiTutorial>().StartTutorial();
            PlayerPrefs.SetInt("FirstTimePlaying", 1);
        }
    }


    private void FixedUpdate()
    {
        CheckForFade();
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("BananasCollected", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("GamesLost", 0);
        PlayerPrefs.SetInt("FirstTimePlaying", 0);
    }



    public void DamagePlayer(int damage)
    {
        audioSource.clip = hurtPlayerAudioClips[Random.Range(0, hurtPlayerAudioClips.Count)];
        audioSource.pitch = Random.Range(0.85f, 1.16f);
        audioSource.Play();

        if (canTakeDamage)
        {
            currentHealth = currentHealth - damage;
            UpdateHealthIcons();
            if (currentHealth < 1)
            {
                GameOver();
            }
        }
    }

    public void HealPlayer(int heal)
    {

        if (currentHealth < maxHealth)
        {
            if (currentHealth + heal > maxHealth)
            {
                ResetHp();
            }
            else
            {
                currentHealth = currentHealth + heal;
                UpdateHealthIcons();
            }
        }
    }

    public void ResetHp()
    {
        currentHealth = maxHealth;
        UpdateHealthIcons();
    }

    private void UpdateHealthIcons()
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

    private void GameOver()
    {

        playerAnimator.SetTrigger("GameOver");
        isGameActive = false;
        PlayerPrefs.SetInt("BananasCollected", bananasCollected);
        PlayerPrefs.SetInt("GamesLost", PlayerPrefs.GetInt("GamesLost") + 1);
        levelLoader.LoadNextLevel(levelToLoad);


    }

    public void PickupBanana(int bananaAmount)
    {
        bananasCollected += bananaAmount;
    }

    public int GetBanana()
    {
        return bananasCollected;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetAmountOfRocksAvailable()
    {
        return amountOfRocksAvailable;
    }

    public int GetMaxAmountOfRocksAvailable()
    {
        return maxAmountOfRocksAvailable;
    }

    public void PickupRock()
    {
        if (amountOfRocksAvailable < maxAmountOfRocksAvailable)
        {
            amountOfRocksAvailable++;
        }
    }

    public void ThrowRock()
    {
        amountOfRocksAvailable--;
    }

    public bool IsRockAvailable()
    {
        if (amountOfRocksAvailable > 0)
        {
            return true;
        }
        else return false;
    }

    public void InvinciblePlayer()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
        canTakeDamage = false;
        isFading = true;
    }

    private void CheckForFade()
    {
        if (isFading == true)
        {
            color = gameObject.GetComponent<SpriteRenderer>().color;
            if (color.a > 0.3)
            {
                color.a = color.a - 1.5f * Time.deltaTime;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
        }

        if (color.a < 0.3)
        {
            isFadingBack = true;
            isFading = false;
        }


        //print(isFading + " fadear man");
        //print(isFadingBack + "anti fadear man");

        if (isFadingBack == true)
        {
            isFading = false;
            color = gameObject.GetComponent<SpriteRenderer>().color;
            if (color.a < 1)
            {
                color.a = color.a + 1.5f * Time.deltaTime;
                gameObject.GetComponent<SpriteRenderer>().color = color;
            }
            else if (color.a >= 1)
            {
                //gameObject.GetComponent<BoxCollider2D>().enabled = true;
                canTakeDamage = true;
                isFadingBack = false;
            }
        }
    }
}
