﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 5;

    AnimationController animationController;

    private void Start()
    {
        animationController = FindObjectOfType<AnimationController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyLaser")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
            animationController.PlayEnemyLaserExplosion(other.transform.position);
            Debug.Log("Player got hit"); // Debug purposes
        }

        if(other.tag == "Coin")
        {
            int value = other.gameObject.GetComponent<Coin>().GetValue();
            FindObjectOfType<GameController>().AddCoins(value);
            Destroy(other.gameObject);
        }
    }

    void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
            Die();
    }
    void Die()
    {
        animationController.PlayPlayerExplosion(transform.position);
    }
}
