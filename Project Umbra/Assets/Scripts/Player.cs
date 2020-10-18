using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 5;

    AnimationController animationController;
    [SerializeField] PlayerHealthBar healthBar = null;

    private void Start()
    {
        healthBar.SetMaxHealth(health);
        animationController = FindObjectOfType<AnimationController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyLaser")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
            animationController.PlayEnemyLaserExplosion(other.transform.position);
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
        if (health - damageDealer.GetDamage() > 0)
        {
            health -= damageDealer.GetDamage();
            healthBar.SetHealth(health);
        }
        else
        {
            health = 0;
            healthBar.SetHealth(health);
            Die();
        }

        damageDealer.Hit();
    }
    void Die()
    {
        animationController.PlayPlayerExplosion(transform.position);
    }
}
