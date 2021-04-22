using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBanana : MonoBehaviour
{
    private bool canPickUpBanana = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true && canPickUpBanana == true)
        {
            collision.GetComponent<PlayerState>().pickupBanana();
            canPickUpBanana = false;
            Destroy(gameObject);
        }
    }


}
