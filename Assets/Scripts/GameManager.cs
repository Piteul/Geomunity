﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Material materialA;
    public Material materialB;

    // Use this for initialization
    void Start() {

        //CreateTriangle("Triangle", new Triangle(new Vector3(0,0), new Vector3(0,1), new Vector3(1,0)));
        //CreateTriangle("Triangle", new Triangle(new Vector3(0,1), new Vector3(1,0), new Vector3(1,1)));

        //CreateSquare("Square 1", new Square(new Triangle(new Vector3(0, 0), new Vector3(0, 1), new Vector3(1, 0)), new Triangle(new Vector3(0, 1), new Vector3(1, 0), new Vector3(1, 1))));

        CreateCube("Cube", 50);


        //for (int i = 0; i < 360; i++) {
        //    CreateCircle(2, i);

        //}
    }

    // Update is called once per frame
    void Update() {

    }



    //Create Functions

    public void CreateCube(string name, int nb) {

        Vector3[] vertices = {
            new Vector3 (0, 0, 0),
            new Vector3 (1, 0, 0),
            new Vector3 (1, 1, 0),
            new Vector3 (0, 1, 0),
            new Vector3 (0, 1, 1),
            new Vector3 (1, 1, 1),
            new Vector3 (1, 0, 1),
            new Vector3 (0, 0, 1),
        };

        int[] triangles = {
            0, 2, 1, //face front
			0, 3, 2,
            2, 3, 4, //face top
			2, 4, 5,
            1, 2, 5, //face right
			1, 5, 6,
            0, 7, 4, //face left
			0, 4, 3,
            5, 4, 7, //face back
			5, 7, 6,
            0, 6, 7, //face bottom
			0, 1, 6
        };

        Mesh mesh = new Mesh();
        mesh.name = "Mesh";

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        GameObject gameObject = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(10, 10, 10);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = materialA;
        mesh.RecalculateNormals();
    }

    public void CreateCircle(int numOfPoints, int nb) {

        float angleStep = 360.0f / (float)numOfPoints;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        Quaternion quaternion = Quaternion.Euler(0.0f, 0.0f, angleStep);

        // Premier Triangle
        vertices.Add(new Vector3(0.0f, 0.0f, 0.0f));  // 1. Centre du cercle.
        vertices.Add(new Vector3(0.0f, 0.5f, 0.0f));  // 2. Premier vertex du contour de cercle (radius = 0.5f)
        vertices.Add(quaternion * vertices[1]);     // 3. Premier vertex du contour de cercle pivoté par l'angle
                                                    // Indices des triangles.
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);
        triangles.Add(2);
        triangles.Add(1);
        triangles.Add(0);

        for (int i = 0; i < numOfPoints - 1; i++) {
            triangles.Add(0);                      // Index du cenntre du cercle.
            triangles.Add(vertices.Count - 1);
            triangles.Add(vertices.Count);
            triangles.Add(vertices.Count);
            triangles.Add(vertices.Count - 1);
            triangles.Add(0);
            vertices.Add(quaternion * vertices[vertices.Count - 1]);
        }


        Mesh mesh = new Mesh();
        mesh.name = "Mesh";

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        GameObject gameObject = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(1, 1, 1);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = materialA;

        gameObject.transform.Rotate(new Vector3(0, nb, 0));

    }

    public void CreateSquare(string name, Square square) {
        //Vector3[] vertices = new Vector3[4];
        //Vector2[] uv = new Vector2[4];
        //int[] triangles = new int[6];

        //vertices[0] = new Vector3(0, 1);
        //vertices[1] = new Vector3(1, 1);
        //vertices[2] = new Vector3(0, 0);
        //vertices[3] = new Vector3(1, 0);

        //uv[0] = new Vector2(0, 1);
        //uv[1] = new Vector2(1, 1);
        //uv[2] = new Vector2(0, 0);
        //uv[3] = new Vector2(1, 0);

        //triangles[0] = 0;
        //triangles[1] = 1;
        //triangles[2] = 2;
        //triangles[3] = 2;
        //triangles[4] = 1;
        //triangles[5] = 3;

        Mesh mesh = new Mesh();
        mesh.name = "Mesh";

        mesh.vertices = square.vertices.ToArray();
        mesh.uv = square.uv.ToArray();
        mesh.triangles = square.triangles.ToArray();

        GameObject gameObject = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(1, 1, 1);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = materialB;
    }


    public void CreateTriangle(string name, Triangle _triangle) {

        //Triangle triangle = new Triangle(0, 0, 0, 1, 1, 0);
        Triangle triangle = _triangle;

        Mesh mesh = new Mesh();
        mesh.name = "Mesh";

        mesh.vertices = triangle.vertices.ToArray();
        mesh.uv = triangle.uv.ToArray();
        mesh.triangles = triangle.triangles.ToArray();

        GameObject gameObject = new GameObject(name, typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(1, 1, 1);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = materialA;
    }




    ////struct 

    public struct Triangle {
        public List<Vector3> vertices { get; set; }
        public List<Vector2> uv { get; set; }
        public List<int> triangles { get; set; }

        public Triangle(Vector3 v1, Vector3 v2, Vector3 v3) {

            vertices = new List<Vector3>();
            uv = new List<Vector2>();
            triangles = new List<int>();

            vertices.Add(v1);
            vertices.Add(v2);
            vertices.Add(v3);

            uv.Add(v1);
            uv.Add(v2);
            uv.Add(v3);

            //recto
            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);
            //verso
            triangles.Add(2);
            triangles.Add(1);
            triangles.Add(0);
        }
    }

    public struct Square {

        public List<Vector3> vertices { get; set; }
        public List<Vector2> uv { get; set; }
        public List<int> triangles { get; set; }
        public Triangle t1 { get; set; }
        public Triangle t2 { get; set; }



        public Square(Triangle _t1, Triangle _t2) {

            t1 = _t1;
            t2 = _t2;

            t1.vertices.Add(t2.vertices[2]);
            vertices = t1.vertices;
            t1.uv.Add(t2.uv[2]);
            uv = t1.uv;

            //recto
            t1.triangles.Add(0);
            t1.triangles.Add(1);
            t1.triangles.Add(2);
            //verso
            t1.triangles.Add(2);
            t1.triangles.Add(1);
            t1.triangles.Add(0);

            //recto
            t2.triangles.Add(2);
            t2.triangles.Add(1);
            t2.triangles.Add(3);
            //verso
            t2.triangles.Add(3);
            t2.triangles.Add(1);
            t2.triangles.Add(2);

            t1.triangles.AddRange(t2.triangles);
            triangles = t1.triangles;

        }

    }
}
