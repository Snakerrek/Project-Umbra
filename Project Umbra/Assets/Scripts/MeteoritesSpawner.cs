using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritesSpawner : MonoBehaviour
{
    [Header("Spawner tweaks")]
    [SerializeField] float timeBetweenMeteoritesSpawn = 300.0f;
    [SerializeField] float maxSize = 1.0f;
    [SerializeField] float minSize = 0.2f;

    [SerializeField] GameObject[] meteoritesPrefabs = null;
    Player player;

    Vector2[] vectors =
    {
        new Vector2(0, 32.0f),
        new Vector2(0, -32.0f),
        new Vector2(32.0f, 0),
        new Vector2(-32.0f, 0),
        new Vector2(-32.0f, -32.0f),
        new Vector2(32.0f, 32.0f),
        new Vector2(-32.0f, 32.0f),
        new Vector2(32.0f,-32.0f)
    };

    private void Start()
    {
        player = FindObjectOfType<Player>();
        InvokeRepeating("SpawnGroupOfMeteorites", timeBetweenMeteoritesSpawn, timeBetweenMeteoritesSpawn);
    }
    void SpawnGroupOfMeteorites()
    {
        int posVarriantIndex = Mathf.FloorToInt(Random.Range(0, vectors.Length));
        Vector2 position = new Vector2(player.transform.position.x, player.transform.position.y) + vectors[posVarriantIndex];

        int caseSwitch = Random.Range(1, 4);
        // Creating shapes from the metheorites groups
        switch(caseSwitch)
        {
            case 1:
                for (int i = 0; i < 5; i++)        //  Triangle    ****
                    for(int j = i; j < 5; j++)     //              ***
                        Spawn(position, i, j);     //              *
                break;
            case 2:
                for (int i = 0; i < 5; i++)       //  Triangle       *
                    for (int j = i; j < 5; j++)   //               ***
                        Spawn(position, j, i);    //              ****
                break;
            case 3:
                for (int i = 0; i < 5; i++)       //  Square       
                    for (int j = 0; j < 5; j++)   //      ***
                        Spawn(position, i, j);    //      ***
                break;

        }


    }

    void Spawn(Vector2 position, float x, float y)
    {
        int prefabIndex = Random.Range(0, meteoritesPrefabs.Length);
        var meteorite = Instantiate(meteoritesPrefabs[prefabIndex], position + new Vector2(x, y), Quaternion.identity);

        float scaleFactor = Random.Range(minSize, maxSize);
        meteorite.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        meteorite.transform.parent = gameObject.transform;

    }
}
