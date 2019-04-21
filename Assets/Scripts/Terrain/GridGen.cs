using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGen : MonoBehaviour
{
    public Material material; 
    public Vector3[] vertices;
    public int[] triangles;
    public int meshLength; //y value of mesh plane
    public int meshWidth; //x value of mesh plane

    void Start()
    {
        //vertices
        Vector3[] vertices = new Vector3[(meshWidth + 1) * (meshLength + 1)]; //individual points of triangles
        for (int i = 0, y = 0; y <= meshLength; y++)
        {
            for (int x = 0; x <= meshWidth; x++, i++)
            {
                vertices[i] = new Vector3(x, Random.Range(0f,2f), y);
            }
        }

        //triangles
        int[] triangles = new int[meshLength * meshWidth * 6];
        for (int i = 0, x = 0; i <= triangles.Length-6; i++, i++, i++, i++, i++, i++, x++)
        {
            //current position
            triangles[i] = x;
            triangles[i + 1] = x + meshLength + 1;
            triangles[i + 2] = x + meshLength + 2;

            //next position
            triangles[i + 4] = x;
            triangles[i + 3] = x + 1;
            triangles[i + 5] = x + meshLength + 2;

            //cuts off the end of each row to ensure no overlap
            if ((x+1) % (meshLength + 1) == 0 || x >= meshLength * meshWidth - 1)
            {
                triangles[i] = 0;
                triangles[i + 1] = 0;
                triangles[i + 2] = 0;
                triangles[i + 3] = 0;
                triangles[i + 4] = 0;
                triangles[i + 5] = 0;
            }
        }

        //create new mesh
        Mesh mesh = new Mesh(); 
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer)); //creates gameobject for mesh, allowing for easy addition/subtraction of components
        gameObject.transform.localScale = new Vector3(5, 1, 5); //sets scale of mesh
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshRenderer>().material = material;
        gameObject.GetComponent<Renderer>().receiveShadows = false; //disables shadows

        //applies semi-determined colors to triangles
        Color[] colors = new Color[vertices.Length]; 
        for (int i = 0; i < vertices.Length; i++)
            colors[i] = new Color(Random.Range(0f, 0.05f) + vertices[i].y/8, 0.5f + vertices[i].y / 10, Random.Range(0f, 0.05f) + vertices[i].y / 10); //should give a snotty green
        mesh.colors = colors;
    }
}

