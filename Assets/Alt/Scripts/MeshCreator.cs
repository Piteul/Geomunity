using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCreator : MonoBehaviour {
	
	public Material mat;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MeshFilter> ();
		gameObject.AddComponent<MeshRenderer> ();

		Vector3[] vertices = new Vector3[3];
		int[] triangles = new int[3];

		vertices[0] = new Vector3(0,0,0);
		vertices[1] = new Vector3(1,0,0);
		vertices[2] = new Vector3(0,1,0);

		triangles [0] = 0;
		triangles [1] = 1;
		triangles [2] = 2;

		Mesh msh = new Mesh ();

		msh.vertices = vertices;
		msh.triangles = triangles;

		gameObject.GetComponent<MeshFilter>().mesh = msh;
		gameObject.GetComponent<MeshRenderer> ().material = mat;
	}
}
