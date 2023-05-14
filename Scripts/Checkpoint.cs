using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerLife = collision.gameObject.GetComponentInChildren<PlayerLife>();
        if (playerLife)
        {
            playerLife.lastCheckPointPos = transform.position;
        }
    }
}
