using UnityEngine;

public class PerlinTerrainGenerator : MonoBehaviour
{
    public int width = 256;
    public int length = 256;
    public int depth = 20;
    public float scale = 5f;
    public float seed;

    void Start()
    {
        seed = Random.Range(0f, 10000f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData); //terrain data = newly generated terrain, and not the default setting
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, length);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights ()
    {
        float[,] lengths = new float[width, length]; //grid of points
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < length; y++) {
                lengths[x, y] = CalculateHeight(x, y); //calculates height at the iterated x and y coord
            }
        }
        return lengths;
    }

    float CalculateHeight (int x, int y) //converts coords into noisemap coords
    {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / length * scale;

        return Mathf.PerlinNoise(xCoord + seed, yCoord + seed); //returns perlin noise at noisemap coords
    }
}