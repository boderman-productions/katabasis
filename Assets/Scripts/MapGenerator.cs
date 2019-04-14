using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject Sea;
    public GameObject Land;
    public GameObject Hill;
    public GameObject Mountain;
    public GameObject Tree;
    public int mapWidth;
    public int mapHeight;
    public float[,] elevationGrid; //grid containing each tile's elevation
    public int noiseSeed; //generates random seed
    public int noiseScale; //how zoomed the map is. 10 - 100


    private void Awake()
    {
        mapWidth = 50;
        mapHeight = 50;
        elevationGrid = new float[mapWidth, mapHeight];
        noiseSeed = Random.Range(0, 1000); //gives noise a random seed. change to a set variable if you want a repeatable level generation.
        noiseScale = 7; //sets the scale of noise generation. 5-12 is a decent range, otherwise land masses get unrealistic
    }

    void Start()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                elevationGrid[i, j] = Mathf.PerlinNoise((float)i / noiseScale + noiseSeed, (float)j / noiseScale + noiseSeed);
                float k = elevationGrid[i, j];
                if (k <= 0.4)
                {
                    Instantiate(Sea, new Vector3(i, 1.9f, j), Quaternion.identity); //spawns sea block
                }
                if (k >= 0.4 && k <= 0.6)
                {
                    float r = Random.Range(2.0f, 2.2f);
                    Instantiate(Land, new Vector3(i, r, j), Quaternion.identity); //spawns land block
                    float r2 = Random.Range(0, 20); //chance of spawning trees on land blocks
                    if (r2 < 1)
                    {
                        Instantiate(Tree, new Vector3(i, r+r, j), Quaternion.identity); //spawns tree
                     }
                }
                if (k >= 0.6 && k <= 0.8)
                {
                    float r = Random.Range(2.3f, 2.9f);
                    Instantiate(Hill, new Vector3(i, r, j), Quaternion.identity); //spawns hill block
                    float r2 = Random.Range(0, 5); //chance of spawning trees on hill blocks
                    if (r2 < 1)
                    {
                        Instantiate(Tree, new Vector3(i, r+r, j), Quaternion.identity); //spawns tree 
                    }
                }
                if (k >= 0.8)
                {
                    float r = Random.Range(3.0f, 3.5f);
                    Instantiate(Mountain, new Vector3(i, r, j), Quaternion.identity); //spawns mountain block
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
