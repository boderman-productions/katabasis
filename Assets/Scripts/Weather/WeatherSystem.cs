using UnityEngine;
using System.Collections;

public class WeatherSystem : MonoBehaviour
{
    public static float minWaterLevel;
    public static float maxWaterLevel;
    public static bool raining;
    public GameObject Rain;
    public Vector3 terrainCoord;
    private int rainX;
    private int rainY;

    void Start()
    {
        minWaterLevel = 1f;
        maxWaterLevel = 15f;
        raining = true;
        Vector3 terrainCoord = GameObject.Find("BaseTerrain").GetComponent<Terrain>().terrainData.size; //gets the dimensions of the base terrain layer to ensure nothing falls outside
    }

    void Update()
    {
        if (raining = true) //standard rain
        {
            rainX = Random.Range(0, PerlinTerrainGenerator.terrainWidth);
            rainY = Random.Range(0, PerlinTerrainGenerator.terrainLength);
            Instantiate(Rain, new Vector3(rainX, 100, rainY), Quaternion.identity); //instantiates random droplet at random coordinates above terrain map
            rainX = Random.Range(0, PerlinTerrainGenerator.terrainWidth);
            rainY = Random.Range(0, PerlinTerrainGenerator.terrainLength);
            Instantiate(Rain, new Vector3(rainX, 100, rainY), Quaternion.identity); //instantiates random droplet at random coordinates above terrain map
            rainX = Random.Range(0, PerlinTerrainGenerator.terrainWidth);
            rainY = Random.Range(0, PerlinTerrainGenerator.terrainLength);
            Instantiate(Rain, new Vector3(rainX, 100, rainY), Quaternion.identity); //instantiates random droplet at random coordinates above terrain map
            rainX = Random.Range(0, PerlinTerrainGenerator.terrainWidth);
            rainY = Random.Range(0, PerlinTerrainGenerator.terrainLength);
            Instantiate(Rain, new Vector3(rainX, 100, rainY), Quaternion.identity); //instantiates random droplet at random coordinates above terrain map
            rainX = Random.Range(0, PerlinTerrainGenerator.terrainWidth);
            rainY = Random.Range(0, PerlinTerrainGenerator.terrainLength);
            Instantiate(Rain, new Vector3(rainX, 100, rainY), Quaternion.identity); //instantiates random droplet at random coordinates above terrain map
        }
    }
}
