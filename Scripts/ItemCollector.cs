using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    public int cherries = 0;
    [SerializeField] public TextMeshProUGUI cherryText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Cherry")
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherryText.text = "Cherries: " + cherries;
            Debug.Log("Cherries");
        }
    }
    public void setCherries(int newcherries)
    {
        cherries = newcherries;
        cherryText.text = "Cherries: " + cherries;
    }
}
