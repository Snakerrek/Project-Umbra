using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Tweaks")]
    [SerializeField] int minEnemyNumberPerSpawn = 0;
    [SerializeField] int maxEnemyNumberPerSpawn = 1;

    [SerializeField] float minSpawnTime = 0;
    [SerializeField] float maxSpawnTime = 1;

    [SerializeField] float minSpawnDistanceFromPlayer = 10.0f;
    [SerializeField] float maxSpawnDistanceFromPlayer = 20.0f;

    [SerializeField][Range(0, 1)] float chanceForSuccessfulSpawn = 0; 
    
    [SerializeField] GameObject[] enemyPrefabs;
    Player player;

    float spawnTime;
    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Spawn()
    {
        if (SpawnOrNot())
        {
            float numberOfEnemies = Mathf.FloorToInt(Random.Range(minEnemyNumberPerSpawn, maxEnemyNumberPerSpawn));
            
            for(int i = 0; i < numberOfEnemies; i++)
            {
                int prefabIndex = Mathf.RoundToInt(Random.Range(0, enemyPrefabs.Length)); // check if it is getting all posible prefabs
                var newEnemy = Instantiate(enemyPrefabs[prefabIndex], CalculatePosition(), Quaternion.identity);
                newEnemy.transform.parent = gameObject.transform;
            }
        }

        // ADD SOME KIND OF INFORMATION FOR PLAYER THAT WAVE IS COMING

        spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private bool SpawnOrNot()
    {
        float randomNumber = Random.Range(0.0f, 1.0f);
        if (randomNumber <= chanceForSuccessfulSpawn)
        {
            Debug.Log("Successful spawn");
            return true;
        }
        else
        {
            Debug.Log("Not successful spawn");
            return false;
        }
    }
    private Vector2 CalculatePosition()
    {
        Vector2 position;
        do
        {
            position = new Vector2(player.transform.position.x, player.transform.position.y) + Random.insideUnitCircle * maxSpawnDistanceFromPlayer;

        } while (distanceFromPlayerIsSmallerThan(minSpawnDistanceFromPlayer, position));

        return position;
    }

    private bool distanceFromPlayerIsSmallerThan(float distanceRequired, Vector2 position)
    {
        float distance = Mathf.Sqrt(Mathf.Pow(position.x - player.transform.position.x, 2) + Mathf.Pow(position.y - player.transform.position.y, 2));

        if (distance < distanceRequired)
            return true;
        else
            return false;
    }
}
