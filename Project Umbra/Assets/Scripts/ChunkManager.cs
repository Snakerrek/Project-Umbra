using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab = null;
    [SerializeField] float chunkSize = 32.0f;
    GameObject player;
    Vector3 playerOriginPos;
    Vector2 playerFixedPos; // Player position relative to chunk size
    Vector2 playerPreviousPos; // For checking purposes
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        playerPreviousPos = GetPlayerPosRelToChunk();
    }

    void Update()
    {
        Debug.Log(GetPlayerPosRelToChunk());
        if (CheckIfPlayerChangedChunk())
        {
            playerFixedPos = GetPlayerPosRelToChunk();
            Vector2 chunk = new Vector2(chunkSize, chunkSize);

            if(!ChunkExistenceCheck(playerFixedPos * chunk))
                SpawnChunk(playerFixedPos * chunk);
        }
    }

    Vector2 GetPlayerPosRelToChunk()
    {
        playerOriginPos = player.transform.position;
        int x;
        int y;
        
        if (playerOriginPos.x < 0)
            x = Mathf.FloorToInt((playerOriginPos.x + 16)/32);
        else if (playerOriginPos.x > 0)
            x = Mathf.CeilToInt((playerOriginPos.x - 16)/32);
        else
            x = 0;

        if (playerOriginPos.y < 0)
            y = Mathf.FloorToInt((playerOriginPos.y + 16)/32);
        else if (playerOriginPos.y > 0)
            y = Mathf.CeilToInt((playerOriginPos.y - 16)/32);
        else
            y = 0;
        
        return new Vector2(x, y);
    }

    bool ChunkExistenceCheck(Vector2 position)
    {
        return Physics.CheckSphere(position, 1.0f);
    }
    void SpawnChunk(Vector2 position)
    {
        Instantiate(chunkPrefab, position, Quaternion.identity, gameObject.transform);
    }
    bool CheckIfPlayerChangedChunk()
    {
        if (GetPlayerPosRelToChunk() != playerPreviousPos)
        {
            playerPreviousPos = GetPlayerPosRelToChunk();
            return true;
        }
        else
            return false;
    }
}
