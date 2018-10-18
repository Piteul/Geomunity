using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour {
	
	public Material mat;

	// Use this for initialization
	//void Start () {
	//	gameObject.AddComponent<MeshFilter> ();
	//	gameObject.AddComponent<MeshRenderer> ();

	//	Vector3[] vertices = new Vector3[3];
	//	int[] triangles = new int[3];

	//	vertices[0] = new Vector3(0,0,0);
	//	vertices[1] = new Vector3(0,1,0);
	//	vertices[2] = new Vector3(1,0,0);

	//	triangles [0] = 0;
	//	triangles [1] = 1;
	//	triangles [2] = 2;

	//	Mesh msh = new Mesh ();

	//	msh.vertices = vertices;
	//	msh.triangles = triangles;

	//	gameObject.GetComponent<MeshFilter>().mesh = msh;
	//	gameObject.GetComponent<MeshRenderer> ().material = mat;
	//}

    void Start () {
		gameObject.AddComponent<MeshFilter> ();
		gameObject.AddComponent<MeshRenderer> ();

		Vector3[] vertices = new Vector3[3];
		int[] triangles = new int[3];

		vertices[0] = new Vector3(0,0,0);
		vertices[1] = new Vector3(0,1,0);
		vertices[2] = new Vector3(1,0,0);

		triangles [0] = 0;
		triangles [1] = 1;
		triangles [2] = 2;

        Vector3 v1 = new Vector3((vertices[0].x + vertices[1].x)/2, (vertices[0].y + vertices[1].y) / 2, (vertices[0].z + vertices[1].z)/ 2);
        Vector3 v2 = new Vector3((vertices[1].x + vertices[2].x)/2, (vertices[1].y + vertices[2].y) / 2, (vertices[1].z + vertices[2].z)/ 2);
        Vector3 v3 = new Vector3((vertices[2].x + vertices[0].x)/2, (vertices[2].y + vertices[0].y) / 2, (vertices[2].z + vertices[0].z)/ 2);

        vertices[0] = v1;
        vertices[1] = v2;
		vertices[2] = v3;







        Mesh msh = new Mesh ();

		msh.vertices = vertices;
		msh.triangles = triangles;

		gameObject.GetComponent<MeshFilter>().mesh = msh;
		gameObject.GetComponent<MeshRenderer> ().material = mat;
	}
}
