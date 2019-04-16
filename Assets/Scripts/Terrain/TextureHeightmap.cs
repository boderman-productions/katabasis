using UnityEngine;
using System.Collections;

public class TextureHeightmap : MonoBehaviour
{
    [System.Serializable] //makes splatheights exposed in inspector
    public class SplatHeights
    {
        public int textureIndex; //index of texture we're using
        public int startingHeight; //height that texture starts
        public int endingHeight;
    }

    public SplatHeights[] splatHeights; //stores all alpha values

    void Start()
    {
        TerrainData terrainData = Terrain.activeTerrain.terrainData;
        float[,,] splatmapData = new float[terrainData.alphamapWidth, 
                                          terrainData.alphamapHeight, 
                                          terrainData.alphamapLayers]; //number of different layers at a coordinate

        for (int y = 0; y < terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < terrainData.alphamapWidth; x++)
            {
                float terrainHeight = terrainData.GetHeight(y,x); //layers the splatmaps properly
                float[] splat = new float[splatHeights.Length];
                for (int i = 0; i < splatHeights.Length; i++)
                {
                    if (terrainHeight >= splatHeights[i].startingHeight && terrainHeight <= splatHeights[i].endingHeight)
                    {
                        splat[i] = 1;
                    }
                }

                for (int j = 0; j < splatHeights.Length; j++)
                {
                    splatmapData[x, y, j] = splat[j];
                }
            }
        }
        terrainData.SetAlphamaps(0, 0, splatmapData);
    }
}