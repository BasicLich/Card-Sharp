using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public Transform target;
    public float chaseRange;
    public float speed;
    public bool lastShot;
    public void TakeDamage(int damage)
    {
        if (Weapon.bulletAmount < 2 && lastShot == true)
        {
            Die();
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Weapon.bulletAmount--;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillLine")
        {
            Destroy(gameObject);
        }
    }
}
