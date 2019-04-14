using UnityEngine;

public class PerlinTerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public int depth = 10;
    public float scale = 5f;

    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData); //terrain data = newly generated terrain, and not the default setting
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights ()
    {
        float[,] heights = new float[width, height]; //grid of points
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heights[x, y] = CalculateHeight(x, y); //calculates height at the iterated x and y coord
            }
        }
        return heights;
    }

    float CalculateHeight (int x, int y) //converts coords into noisemap coords
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        return Mathf.PerlinNoise(xCoord, yCoord); //returns perlin noise at noisemap coords
    }
}