﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Material materialA;
    public Material materialB;

    // Use this for initialization
    void Start() {

        //CreateTriangle("Triangle", new Triangle(0, 0, 0, 1, 1, 0));
        //CreateTriangle("Triangle 1", new Triangle(0, 1, 1, 0, 1, 1));

        CreateSquare("Square 1", new Square(new Triangle(0, 0, 0, 1, 1, 0), new Triangle(0, 1, 1, 0, 1, 1)));



    }

    // Update is called once per frame
    void Update() {

    }

    public void CreateCube(string name, Square _square) {

        Square square = _square;
        //Square square2 = new Square(new Triangle(square.vertices[2].x, square.vertices[2].y, square.vertices[3].x, square.vertices[3].y, square.vertices[2].x))


    }

    public void CreateCube() {

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

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        //mesh.Optimize();
        mesh.RecalculateNormals();
    }

    public void CreateCircle(int numOfPoints) {

        float angleStep = 360.0f / (float)numOfPoints;
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        Quaternion quaternion = Quaternion.Euler(0.0f, 0.0f, angleStep);

        // Make first triangle.
        vertices.Add(new Vector3(0.0f, 0.0f, 0.0f));  // 1. Circle center.
        vertices.Add(new Vector3(0.0f, 0.5f, 0.0f));  // 2. First vertex on circle outline (radius = 0.5f)
        vertices.Add(quaternion * vertices[1]);     // 3. First vertex on circle outline rotated by angle)
                                                        // Add triangle indices.
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);
        for (int i = 0; i < numOfPoints - 1; i++) {
            triangles.Add(0);                      // Index of circle center.
            triangles.Add(vertices.Count - 1);
            triangles.Add(vertices.Count);
            vertices.Add(quaternion * vertices[vertices.Count - 1]);
        }
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
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
        gameObject.GetComponent<MeshRenderer>().material = materialA;
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
        gameObject.transform.localScale = new Vector3(2, 2, 2);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = materialA;
    }

    public struct Triangle {
        public List<Vector3> vertices { get; set; }
        public List<Vector2> uv { get; set; }
        public List<int> triangles { get; set; }

        public Triangle(int a, int b, int c, int d, int e, int f) {

            vertices = new List<Vector3>();
            uv = new List<Vector2>();
            triangles = new List<int>();

            vertices.Add(new Vector3(a, b));
            vertices.Add(new Vector3(c, d));
            vertices.Add(new Vector3(e, f));

            uv.Add(new Vector3(a, b));
            uv.Add(new Vector3(c, d));
            uv.Add(new Vector3(e, f));


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
