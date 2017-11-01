using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : Terrains
{
    public Transform waterSuface;
    public bool tsunami = true;
    [Range(3f, 8f)] public float tsunamiPeriod;
    [Range(0f, 5f)] public float waveSpeed = 1.0f;
    [Range(0f, 10f)] public float waveAmp = 1.0f;
    [Range(0f, 10f)] public float waveFreq = 0;
    [Range(0f, 359f)] public float waveDirection = 0;
    public float waveX, waveZ;
    public bool isTsunami = false;
    Vector3[] waveVertices;
    Vector3[] vertices;
    Material mat;
    Mesh mesh;
    MeshCollider col;
    float s, a, f, d, t;
    
    void Start ()
    {
        mat = waterSuface.GetComponent<Renderer>().material;
        mesh = waterSuface.GetComponent<MeshFilter>().mesh;
        col = waterSuface.GetComponent<MeshCollider>();
        waveVertices = mesh.vertices;
        vertices = new Vector3[waveVertices.Length];
        if (tsunami)
        {
            s = waveSpeed;
            a = waveAmp;
            f = waveFreq;
            d = waveDirection;
            OceanCurrent();
            InvokeRepeating("Tsunami", tsunamiPeriod, tsunamiPeriod*2);
        }
        else
        {
            InvokeRepeating("OceanCurrent", 0, tsunamiPeriod);
        }
    }
    void Update()
    {
        s = Mathf.MoveTowards(s, waveSpeed, Time.deltaTime);
        a = Mathf.MoveTowards(a, waveAmp,  Time.deltaTime);
        f = Mathf.MoveTowards(f, waveFreq,  Time.deltaTime);
        d = Mathf.MoveTowards(d, waveDirection,  10*Time.deltaTime);
    }
    void FixedUpdate()
    {
        Wave();
    }

    void Wave()
    {
        t += Time.fixedDeltaTime * s;
        waveX = Mathf.Cos(d * Mathf.PI / 180);
        waveZ = Mathf.Sin(d * Mathf.PI / 180);
        mat.mainTextureOffset += new Vector2(s * waveX, s * waveZ) * Time.fixedDeltaTime / 10;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = waveVertices[i];
            vertex.y += (1 + Mathf.Cos(t  + (waveVertices[i].x * waveX + waveVertices[i].z * waveZ) * (1 + 0.1f * f))) * a;
            vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        col.sharedMesh = null;
        col.sharedMesh = mesh;
    }

    void OceanCurrent()
    {
        waveDirection = Random.Range(0, 180);
        waveSpeed = Random.Range(2f, 4f);
        waveAmp = Random.Range(1f, 3f);
        waveFreq = Random.Range(3f, 5f);
        isTsunami = false;
    }
    void Tsunami()
    {
        waveAmp = Random.Range(4f, 6f);
        waveFreq = Random.Range(5f, 10f);
        waveSpeed = Random.Range(1f, 2f);
        waveDirection = d;
        isTsunami = true;
        Invoke("OceanCurrent", tsunamiPeriod);
    }
}
