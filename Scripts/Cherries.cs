using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cherries : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {

            
            Destroy(gameObject);
        }
    }
}
