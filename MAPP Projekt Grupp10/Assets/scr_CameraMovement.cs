using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraMovement : MonoBehaviour
{
    public GameObject player;
    [SerializeField] float offsetX;
    [SerializeField] float offsetY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0, player.transform.position.y + offsetY);
    }

    // Update is called once per frazme
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + offsetX, transform.position.y, -10);
    }
}

