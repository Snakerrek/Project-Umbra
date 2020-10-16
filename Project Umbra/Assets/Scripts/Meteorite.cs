using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float lifespan = 30.0f;

    private Rigidbody2D rb;
    Player player;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        FacePlayer();
    }

    void Update()
    {
        rb.AddForce(rb.transform.up * speed * Time.deltaTime);
        Destroy(gameObject, lifespan);
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
