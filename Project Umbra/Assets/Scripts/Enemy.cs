using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement Settings")]

    [SerializeField] float enemyOffset = 4.0f;
    [SerializeField] float enemySpeed = 3.0f;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        if (CheckDistanceFromPlayer() > enemyOffset)
            FollowPlayer();
        FacePlayer();
    }

    void FollowPlayer()
    {
        Vector2 target = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target, enemySpeed * Time.deltaTime);
    }

    float CheckDistanceFromPlayer()
    {
        float distance;
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 enemyPos = new Vector2(transform.position.x, transform.position.y);

        distance = Mathf.Sqrt(Mathf.Pow(enemyPos.x - playerPos.x, 2) + Mathf.Pow(enemyPos.y - playerPos.y, 2));
        return distance;
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
