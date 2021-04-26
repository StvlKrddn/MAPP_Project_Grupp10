using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_LevelGenerator : MonoBehaviour
{
    [SerializeField] List<Transform> levelPartsList;
    [SerializeField] GameObject player;
    [SerializeField] float distanceBeforeSpawning;


    private Vector3 previousEndPoint; 
    // Start is called before the first frame update
    void Start()
    {
        Transform levelToSpawn = levelPartsList[Random.Range(0, levelPartsList.Count)];

        Transform temp = levelToSpawn.Find("StartPoint");

        float test = levelToSpawn.position.x - temp.position.x;

        print(test + "Hur stor är distansen");

        Transform hej = Instantiate(levelToSpawn, new Vector3(player.transform.position.x + test - 1, player.transform.position.y -3),Quaternion.identity);

        previousEndPoint = hej.Find("EndPoint").transform.position;

        print(previousEndPoint.x + "Var är endpointen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, previousEndPoint) < distanceBeforeSpawning)
        {
            addLevelPart(levelPartsList[Random.Range(0, levelPartsList.Count)], previousEndPoint);
        }
    }


    private void addLevelPart(Transform prefab, Vector3 position)
    {
        Transform temp = prefab.Find("StartPoint");

        float test = prefab.position.x - temp.position.x;

        Instantiate(prefab, new Vector3(position.x + test, position.y), Quaternion.identity);

        previousEndPoint = prefab.Find("EndPoint").position;
    }
}
