using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder2 : MonoBehaviour {
    public float rayon;
    public float hauteur;
    public int nMeridiens;
    
    // Use this for initialization
    void Start () {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        Mesh mesh = filter.mesh;
        mesh.Clear();

        List<Vector3> sommets = new List<Vector3>();
        List<Facette> facettes = new List<Facette>();
        List<int> indexFacettes = new List<int>();

        for (int i = 0; i < nMeridiens; ++i)
        {
            sommets.Add(new Vector3(rayon * (float)Math.Cos(i * 2 * Math.PI / nMeridiens), rayon * (float)Math.Sin(i * 2 * Math.PI / nMeridiens), hauteur / 2));
            sommets.Add(new Vector3(rayon * (float)Math.Cos(i * 2 * Math.PI / nMeridiens), rayon * (float)Math.Sin(i * 2 * Math.PI / nMeridiens), -hauteur / 2));
        }

        sommets.Add(new Vector3(0, 0, hauteur / 2));
        sommets.Add(new Vector3(0, 0, -hauteur / 2));
        
        for (int i = 0; i < 2 * nMeridiens; i += 2)
        {
            //Cote
            //facettes.Add(new Facette(sommets[i], sommets[(i + 1) % (2 * nMeridiens)], sommets[(i + 3) % (2 * nMeridiens)]));
            //facettes.Add(new Facette(sommets[i], sommets[(i + 3) % (2 * nMeridiens)], sommets[(i + 2) % (2 * nMeridiens)]));

            ////Haut et bas
            //facettes.Add(new Facette(sommets[sommets.Count - 2], sommets[i], sommets[(i + 2) % (2 * nMeridiens)]));
            //facettes.Add(new Facette(sommets[sommets.Count - 1], sommets[(i + 1) % (2 * nMeridiens)], sommets[(i + 3) % (2 * nMeridiens)]));
            Debug.Log("facette");
            Debug.Log(i);
            Debug.Log((i + 1) % (2 * nMeridiens));
            Debug.Log((i + 3) % (2 * nMeridiens));

            indexFacettes.Add(i);
            indexFacettes.Add((i + 1) % (2 * nMeridiens));
            indexFacettes.Add((i + 3) % (2 * nMeridiens));

            indexFacettes.Add(i);
            indexFacettes.Add((i + 3) % (2 * nMeridiens));
            indexFacettes.Add((i + 2) % (2 * nMeridiens));

            indexFacettes.Add(sommets.Count - 2);
            indexFacettes.Add(i);
            indexFacettes.Add((i + 2) % (2 * nMeridiens));

            indexFacettes.Add(sommets.Count - 1);
           
            indexFacettes.Add((i + 3) % (2 * nMeridiens));
            indexFacettes.Add((i + 1) % (2 * nMeridiens));

        }

        mesh.vertices = sommets.ToArray();
        mesh.triangles = indexFacettes.ToArray();
        

        mesh.RecalculateBounds();

    }

    public class Facette
    {
        public Vector3 p1, p2, p3;

        public Facette(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
    }

    //public class Mesh
    //{
    //    public List<Vector3> sommets;
    //    public List<Facette> facettes;

    //    public Mesh(List<Vector3> sommets, List<Facette> facettes)
    //    {
    //        this.sommets = sommets;
    //        this.facettes = facettes;
    //    }
    //}



    // Update is called once per frame
    void Update () {
		
	}
}
