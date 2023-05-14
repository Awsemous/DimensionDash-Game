using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public Vector2 lastCheckPointPos = new Vector2(-3,0);

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        lastCheckPointPos= gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
             
        }
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.velocity = Vector3.zero;
        anim.SetTrigger("cleandeath");
        gameObject.transform.position = lastCheckPointPos;
        var Items = gameObject.GetComponent<ItemCollector>();
        Items.setCherries(0);
    }
}
