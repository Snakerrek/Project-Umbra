﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]

    [SerializeField] float enemyOffset = 4.0f;
    [SerializeField] float enemySpeed = 3.0f;

    [Header("Attack Settings")]

    [SerializeField] float enemyShootDistance = 6.0f;
    [SerializeField] float enemyShootRatio = 2.0f;
    [SerializeField] GameObject projectilePrefab = null;

    Player player;
    bool canShoot = true;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void FixedUpdate()
    {
        if(IsDistanceFromPlayerSmallerThan(enemyShootDistance) && canShoot)
            StartCoroutine(Shoot());

        FollowPlayer();
        FacePlayer();
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
}
