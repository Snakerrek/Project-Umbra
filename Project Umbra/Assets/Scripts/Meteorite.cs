using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] float lifespan = 30.0f;

    private Rigidbody2D rb;
    Player player;
    float timer;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        FacePlayer();
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        rb.AddForce(rb.transform.up * speed * Time.deltaTime);

        if(timer > lifespan && DistanceFromPlayer() > 16)
            Destroy(gameObject);
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

    float DistanceFromPlayer()
    {
        float distance;
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 meteoritePos = new Vector2(transform.position.x, transform.position.y);

        distance = Mathf.Sqrt(Mathf.Pow(meteoritePos.x - playerPos.x, 2) + Mathf.Pow(meteoritePos.y - playerPos.y, 2));
        return distance;
    }
}
