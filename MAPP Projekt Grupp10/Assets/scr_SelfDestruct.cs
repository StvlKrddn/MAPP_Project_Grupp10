using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SelfDestruct : MonoBehaviour
{
    public GameObject player;

    [SerializeField] GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (player != null)
        { 
            if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 300)
            {
                Destroy(parent);
                print("har sprängts");
            }
        }
    }
}
