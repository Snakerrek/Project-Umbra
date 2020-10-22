using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] int health = 2;
    [SerializeField] int coinsToDrop = 1;

    [Header("Movement Settings")]

    [SerializeField] float enemyOffset = 4.0f;
    [SerializeField] float enemySpeed = 3.0f;

    [Header("Attack Settings")]

    [SerializeField] float enemyShootDistance = 6.0f;
    [SerializeField] float enemyShootRatio = 2.0f;

    [Header("Prefabs")]
    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] GameObject coinPrefab = null;
    [SerializeField] EnemyHealthBar healthBar = null;
    [SerializeField] GameObject healPrefab = null;

    Player player;
    AnimationController animationController;

    bool canShoot = true;
    private void Start()
    {
        healthBar.SetMaxHealth(health);
        player = FindObjectOfType<Player>();
        animationController = FindObjectOfType<AnimationController>();
    }
    void FixedUpdate()
    {
        if(IsDistanceFromPlayerSmallerThan(enemyShootDistance) && canShoot)
            StartCoroutine(Shoot());

        FollowPlayer();
        FacePlayer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerLaser")
        {
            ManagePlayerLaserExplosionAnim(other);
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Instantiate(projectilePrefab, position, transform.rotation);
        yield return new WaitForSeconds(enemyShootRatio);
        canShoot = true;
    }
    void FollowPlayer()
    {
        if(!IsDistanceFromPlayerSmallerThan(enemyOffset * 2))
        {
            Vector2 target = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, enemySpeed * 2 * Time.deltaTime);
        }
        else if (!IsDistanceFromPlayerSmallerThan(enemyOffset))
        {
            Vector2 target = player.transform.position;
            transform.position = Vector2.MoveTowards(transform.position, target, enemySpeed * Time.deltaTime);
        }

    }

    bool IsDistanceFromPlayerSmallerThan( float targetDistance)
    {
        float distance;
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 enemyPos = new Vector2(transform.position.x, transform.position.y);

        distance = Mathf.Sqrt(Mathf.Pow(enemyPos.x - playerPos.x, 2) + Mathf.Pow(enemyPos.y - playerPos.y, 2));
        return distance < targetDistance;
    }
    void FacePlayer()
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

        Vector2 direction = new Vector2(
            playerPos.x - transform.position.x,
            playerPos.y - transform.position.y
            );

        transform.up = direction;
    }

    void Die()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random <= 0.1) // 10% chance for heal drop
            DropHeal();
        else
            DropCoins(coinsToDrop);
        Debug.Log(random);
        Destroy(gameObject);
        animationController.PlayEnemyExplosion(transform.position);
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

    void DropCoins(int amount)
    {
        Instantiate(coinPrefab, gameObject.transform.position, Quaternion.identity);
    }

    void DropHeal()
    {
        Instantiate(healPrefab, gameObject.transform.position, Quaternion.identity);
    }

    void ManagePlayerLaserExplosionAnim(Collider2D laser)
    {
        if (laser.gameObject.name == "Green_laser(Clone)")
            animationController.PlayGreenPlayerLaserExplosion(laser.transform.position);
    }
}
