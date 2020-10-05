using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBodiesGenerator : MonoBehaviour
{

    [Header("Stars Settings")]
    [SerializeField] int minStarsToGenerate = 0;
    [SerializeField] int maxStarsToGenerate = 1;

    [Header("Galaxies Settings")]
    [SerializeField] int minGalaxiesToGenerate = 0;
    [SerializeField] int maxGalaxiesToGenerate = 1;

    [Header("Chunk Information")]
    [SerializeField] float chunkWidth = 32.0f;
    [SerializeField] float chunkHeight = 32.0f;
    Vector2 chunkPos;

    [Header("Prefabs")]
    [SerializeField] GameObject[] starPrefabs = null;
    [SerializeField] GameObject[] galaxyPrefabs = null;
    void Start()
    {
        chunkPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        GenerateStars();
        GenerateGalaxies();
    }

    void GenerateStars()
    {
        int amountOfStars = Mathf.RoundToInt(Random.Range(minStarsToGenerate, maxStarsToGenerate));
        for(int i = 0; i < amountOfStars; i++)
        {
            // Generating random numbers
            Vector2 starPosition = GetRandomPosition();
            Quaternion starRotation = GetRandomRotation();
            int starPrefabIndex = Mathf.RoundToInt(Random.Range(0, starPrefabs.Length - 1));

            // Instantiating
            var newStar = Instantiate(starPrefabs[starPrefabIndex], chunkPos + starPosition, starRotation, gameObject.transform);
            Debug.Log(gameObject.transform);
        }
    }
    void GenerateGalaxies()
    {
        int amountOfGalaxies = Mathf.RoundToInt(Random.Range(minGalaxiesToGenerate, maxGalaxiesToGenerate));
        for (int i = 0; i < amountOfGalaxies; i++)
        {
            // Generating random numbers
            Vector2 galaxyPosition = GetRandomPosition();
            Quaternion galaxyRotation = GetRandomRotation();
            int galaxyPrefabIndex = Mathf.RoundToInt(Random.Range(0, galaxyPrefabs.Length - 1));

            // Instantiating
            var newGalaxy = Instantiate(starPrefabs[galaxyPrefabIndex], chunkPos + galaxyPosition, galaxyRotation);
            newGalaxy.transform.parent = gameObject.transform;
        }
    }
    Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-(chunkWidth/2), (chunkWidth / 2)), Random.Range(-(chunkHeight / 2), (chunkHeight / 2)));
    }
    Quaternion GetRandomRotation()
    {
        return Quaternion.Euler(0, 0, Random.Range(0.0f, 360.0f));
    }
}
