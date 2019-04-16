using UnityEngine;
using System.Collections;

public class WeatherSystem : MonoBehaviour
{
    [System.Serializable] //exposes rain values to editor
    public class rainEditor
    {
        public int rainAmount;
    }

    public GameObject Rain;
    public Vector3 terrainCoord;
    public int rainX;
    public int rainY;

    void Start()
    {
        Vector3 terrainCoord = GameObject.Find("BaseTerrain").GetComponent<Terrain>().terrainData.size; //gets the dimensions of the base terrain layer to ensure nothing falls outside
        Debug.Log(terrainCoord);
    }

    void Update()
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
