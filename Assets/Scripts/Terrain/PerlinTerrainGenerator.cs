using UnityEngine;

public class PerlinTerrainGenerator : MonoBehaviour
{
    public static int terrainWidth = 512;
    public static int terrainLength = 512;
    public int depth = 20;
    public float scale = 5f;
    public float seed;

    void Awake()
    {
        seed = Random.Range(0f, 10000f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData); //terrain data = newly generated terrain, and not the default setting
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = terrainWidth + 1;
        terrainData.size = new Vector3(terrainWidth, depth, terrainLength);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights ()
    {
        float[,] terrainLengths = new float[terrainWidth, terrainLength]; //grid of points
        for (int x = 0; x < terrainWidth; x++) {
            for (int y = 0; y < terrainLength; y++) {
                terrainLengths[x, y] = CalculateHeight(x, y); //calculates height at the iterated x and y coord
            }
        }
        return terrainLengths;
    }

    float CalculateHeight (int x, int y) //converts coords into noisemap coords
    {
        float xCoord = (float)x / terrainWidth * scale;
        float yCoord = (float)y / terrainLength * scale;

        return Mathf.PerlinNoise(xCoord + seed, yCoord + seed); //returns perlin noise at noisemap coords
    }
}