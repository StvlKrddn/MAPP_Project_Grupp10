using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    [SerializeField] private Button attackButton;
    private PlayerState playerState;

    private void Start()
    {
        playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        attackButton = attackButton.GetComponent<Button>();
        attackButton.onClick.AddListener(playerDoDamage);
    }

    private void playerDoDamage()
    {
        playerState.damageEnemy();
        playerState.endTurn();
    }


}