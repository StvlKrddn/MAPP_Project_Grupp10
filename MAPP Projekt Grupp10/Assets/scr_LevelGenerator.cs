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
        Transform temp = prefab.Find("StartPosition");

        Instantiate(prefab, position, Quaternion.identity);

        previousEndPoint = prefab.Find("EndPosition").position;
    }
}
