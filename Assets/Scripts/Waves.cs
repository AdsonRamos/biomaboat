using UnityEngine;
using System.Collections;
 
public class Waves : MonoBehaviour {
    
    public static Waves instance;
    public float scale = 0.1f;
    public float speed = 1.0f;
    public float waveDistance = 1f;
    public float noiseStrength = 1f;
    public float noiseWalk = 1f;

    MeshFilter meshFilter;
    Mesh mesh;
    Vector3[] vertices;
    private float offset;

    private void Awake() {
        if (instance == null){
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
        meshFilter = GetComponent<MeshFilter>();
    }

    void Start()
    {
        CreateMeshLowPoly(meshFilter);
    }

    /// <summary>
    /// Rearranges the mesh vertices to create a 'low poly' effect
    /// </summary>
    /// <param name="mf">Mesh filter of gamobject</param>
    /// <returns></returns>
    MeshFilter CreateMeshLowPoly(MeshFilter mf)
    {
        mesh = mf.sharedMesh;

        //Get the original vertices of the gameobject's mesh
        Vector3[] originalVertices = mesh.vertices;

        //Get the list of triangle indices of the gameobject's mesh
        int[] triangles = mesh.triangles;

        //Create a vector array for new vertices 
        Vector3[] vertices = new Vector3[triangles.Length];
        
        //Assign vertices to create triangles out of the mesh
        for (int i = 0; i < triangles.Length; i++)
        {
            vertices[i] = originalVertices[triangles[i]];
            triangles[i] = i;
        }

        //Update the gameobject's mesh with new vertices
        mesh.vertices = vertices;
        mesh.SetTriangles(triangles, 0);
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        this.vertices = mesh.vertices;

        return mf;
    }

    private void Update() {
        offset += Time.deltaTime * speed;
    }

    public float GetWaveYPos(float x_coord, float z_coord)
    {
        float y_coord = 0f;
 
        y_coord += Mathf.Sin((offset + z_coord) / waveDistance) * scale;
        y_coord += Mathf.PerlinNoise(x_coord + noiseWalk, z_coord + Mathf.Sin(offset * 0.1f)) * noiseStrength;
        return y_coord;
    }
}