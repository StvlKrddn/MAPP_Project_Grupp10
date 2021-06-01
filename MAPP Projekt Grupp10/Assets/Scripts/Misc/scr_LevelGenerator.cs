using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LevelGenerator : MonoBehaviour
{
    [SerializeField] List<Transform> levelPartsList1;
    [SerializeField] List<Transform> levelPartsList2;
    [SerializeField] List<Transform> levelPartsList3;
    [SerializeField] GameObject player;
    [SerializeField] float distanceBeforeSpawning;


    [SerializeField] int timeBetweenDifficulty;

    private int timeElapsed = 0;

    [SerializeField] Transform firstPart;
    private Vector3 previousEndPoint;

    [SerializeField] private float rateOfIncreaseMovement;

    [SerializeField] private float maxMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Transform levelToSpawn = firstPart;
        Transform temp = levelToSpawn.Find("StartPoint");
        float test = levelToSpawn.position.x - temp.position.x;

        //print(test + "Hur stor är distansen");

        Transform hej = Instantiate(levelToSpawn, new Vector3(player.transform.position.x + test - 1, player.transform.position.y -3),Quaternion.identity);

        previousEndPoint = hej.Find("EndPoint").transform.position;

        //print(previousEndPoint.x + "Var är endpointen");
    }
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, previousEndPoint) < distanceBeforeSpawning)
        {

            Transform toBeSpawned = determineLevelPart();
                
            if(levelPartsList1.Contains(toBeSpawned))
            {
                //print("spawna level part 1");
            }

            if (levelPartsList2.Contains(toBeSpawned)) 
            {
                //print("spawna level part 2");
            }
            if(levelPartsList3.Contains(toBeSpawned))
            {
                //print("spawna level part 3");
            }

            addLevelPart(toBeSpawned, previousEndPoint);
        }
    }

    private void FixedUpdate()
    {
        player.GetComponent<Scr_Movement>().baseMovement += rateOfIncreaseMovement;

        if(player.GetComponent<Scr_Movement>().baseMovement >= maxMovementSpeed)
        {
            player.GetComponent<Scr_Movement>().baseMovement = maxMovementSpeed;
            //print("max är uppnåd");
        }

        timeElapsed += 1;
    }

    private Transform determineLevelPart()
    {
        if(timeElapsed < (timeBetweenDifficulty/5))
        {
            return levelPartsList1[Random.Range(0, levelPartsList1.Count)];
        }
        if(timeElapsed < (timeBetweenDifficulty / 5)*2)
        {
            //print(" vilken siffra blir det" + (Random.Range(0, 2)));
            if (Random.Range(0, 2) == 0)
            {
                return levelPartsList1[Random.Range(0, levelPartsList1.Count)];
            }
            else
            {
                return levelPartsList2[Random.Range(0, levelPartsList2.Count)];
            }

        }
        if(timeElapsed < (timeBetweenDifficulty / 5) * 3)
        {
            return levelPartsList2[Random.Range(0, levelPartsList2.Count)];
        }
        if(timeElapsed < (timeBetweenDifficulty / 5) * 4)
        {
          
            if (Random.Range(0, 2) == 0)
            {
                return levelPartsList2[Random.Range(0, levelPartsList2.Count)];
            }
            else
            {
                return levelPartsList3[Random.Range(0, levelPartsList3.Count)];
            }
        }

        if(timeElapsed < (timeBetweenDifficulty / 5) * 5)
        {
            return levelPartsList3[Random.Range(0, levelPartsList3.Count)];
        }





        return levelPartsList3[Random.Range(0, levelPartsList3.Count)];
    }

    private void addLevelPart(Transform prefab, Vector3 position)
    {
        //print("händer detta eller ej");
        Transform temp = prefab.Find("StartPoint");
        float test = prefab.position.x - temp.position.x;
        Transform current = Instantiate(prefab, new Vector3(position.x + test, position.y), Quaternion.identity);
        previousEndPoint = current.Find("EndPoint").position;
        current.Find("SelfDestruct").GetComponent<scr_SelfDestruct>().player = player;
    }
}
