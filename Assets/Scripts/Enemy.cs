using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 4;
    public float fadeMulti = 0.8f;

    private Color fade;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        fade = GetComponent<SpriteRenderer>().color;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Crash!");
            Destroy(this.gameObject);
        }
        if (collider.CompareTag("Projectile"))
        {
            health--;
            Debug.Log("Health = " + health);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                fade.a *= fadeMulti;
                this.GetComponent<SpriteRenderer>().color = fade;
            }
        }
    }
}
