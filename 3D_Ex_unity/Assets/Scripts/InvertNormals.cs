using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class InvertNormals : MonoBehaviour {
    void Start() {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++) 
            normals[i] = -normals[i];
        mesh.normals = normals;

        // Развернуть треугольники
        int[] triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3) {
            (triangles[i], triangles[i+1]) = (triangles[i+1], triangles[i]);
        }
        mesh.triangles = triangles;
    }
}