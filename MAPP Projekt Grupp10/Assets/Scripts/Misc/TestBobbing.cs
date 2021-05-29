using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBobbing : MonoBehaviour
{
    float originalY;
    public float floatStrength;
    public float floatSpeed;
    
    void Awake()
    {
        originalY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, originalY + (Mathf.Sin(Time.time * floatSpeed) * floatStrength));
    }
}
