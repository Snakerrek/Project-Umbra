using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBodiesGenerator : MonoBehaviour
{

    [Header("Stars Settings")]
    [SerializeField] int minStarsToGenerate = 0;
    [SerializeField] int maxStarsToGenerate = 1;
    [SerializeField] float minStarScale = 0f;
    [SerializeField] float maxStarScale = 1.0f;

    [Header("Galaxies Settings")]
    [SerializeField] int minGalaxiesToGenerate = 0;
    [SerializeField] int maxGalaxiesToGenerate = 1;
    [SerializeField] float minGalaxyScale = 0f;
    [SerializeField] float maxGalaxyScale = 1.0f;

    [Header("Chunk Information")]
    [SerializeField] float chunkWidth = 32.0f;
    [SerializeField] float chunkHeight = 32.0f;
    Vector2 chunkPos;

    [Header("Prefabs")]
    [SerializeField] GameObject[] starPrefabs = null;
    [SerializeField] GameObject[] galaxyPrefabs = null;

    Color[] colors = {
        new Color(255f/255, 150f/255, 223f/255, 231f/255),
        new Color(255f/255, 242f/255, 150f/255, 231f/255),
        new Color(197f/255, 255f/255, 150f/255, 231f/255),
        new Color(150f/255, 255f/255, 234f/255, 231f/255),
        new Color(150f/255, 212f/255, 255f/255, 231f/255),
        new Color(150f/255, 154f/255, 255f/255, 231f/255),
        new Color(255f/255, 255f/255, 255f/255, 231f/255),

    };
    void Start()
    {
        chunkPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        GenerateStars();
        if(maxGalaxiesToGenerate > 0)
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

            //Changing scale of the star
            float scaleFactor = Random.Range(minStarScale, maxStarScale);
            newStar.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            //Changing color
            newStar.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        }
    }
    void GenerateGalaxies()
    {
        int amountOfGalaxies = Random.Range(minGalaxiesToGenerate, maxGalaxiesToGenerate + 1);
        for (int i = 0; i < amountOfGalaxies; i++)
        {
            // Generating random numbers
            Vector2 galaxyPosition = GetRandomPosition();
            Quaternion galaxyRotation = GetRandomRotation();
            int galaxyPrefabIndex = Mathf.RoundToInt(Random.Range(0, galaxyPrefabs.Length - 1));

            // Instantiating
            var newGalaxy = Instantiate(galaxyPrefabs[galaxyPrefabIndex], chunkPos + galaxyPosition, galaxyRotation, gameObject.transform);

            //Changing scale of the galaxy
            float scaleFactor = Random.Range(minGalaxyScale, maxGalaxyScale);
            newGalaxy.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            //Changing color
            newGalaxy.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
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
