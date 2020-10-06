using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    Player player;
    float chunkSize = 32.0f;
    void Start()
    {
        player = FindObjectOfType<Player>();
        InvokeRepeating("DestroyChunk", 2.0f, 2.0f); // To spare some computing power
    }

    void DestroyChunk() // Destroying chunk if it is farfrom the player
    {
        float distance;
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 chunkPos = new Vector2(transform.position.x, transform.position.y);

        distance = Mathf.Sqrt(Mathf.Pow(chunkPos.x - playerPos.x, 2) + Mathf.Pow(chunkPos.y - playerPos.y, 2));

        if(distance >= 2 * chunkSize)
            Destroy(gameObject);
    }
}
