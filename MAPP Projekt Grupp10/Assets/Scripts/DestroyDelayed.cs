using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelayed : MonoBehaviour
{

    [SerializeField] private float timeBeforeDestroy = 1;

    private void Awake()
    {
        Destroy(gameObject, timeBeforeDestroy);
    }

}
