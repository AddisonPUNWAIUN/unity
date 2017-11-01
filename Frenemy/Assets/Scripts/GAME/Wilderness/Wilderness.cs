using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wilderness : Terrains
{
    public List<GameObject> plates;
    Transform ground;
    public int groundUnits = 10;
    public float amplitude = 10;
    public float shakePeriod = 0.1f;
    public float crackPeriod = 1.5f;
    Player player;
    static public bool crack = false;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
        ground = transform.Find("ground");
        Transform groundBase = transform.Find("ground/ground base");
        Transform stones = transform.Find("stones");
        GameObject stone;
        Vector3 startPos = stones.position;
        int cols = (int)groundBase.localScale.x;
        int rows = (int)groundBase.localScale.z;
        for (int i = 0; i < stones.childCount; i++)
        {
            stone = stones.GetChild(i).gameObject;
            plates.Add(stone);
        }
        for (int x = 0; x < cols; x++)
        {
            for (int z = 0; z < rows; z++)
            {
                Instantiate(plates[Random.Range(0, plates.Count)], 
                                   startPos + new Vector3(x * groundUnits, 0, z * groundUnits), 
                                   Quaternion.Euler(Vector3.up * Random.Range(0, 360)), 
                                   ground);
            }
        }
        InvokeRepeating("AmpInvert", shakePeriod, shakePeriod);
        InvokeRepeating("Crack", crackPeriod, crackPeriod);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 dist = (Vector3.right  + Vector3.forward )* amplitude * Time.fixedDeltaTime;
        ground.Translate(dist);
        if (player.isGrounded)
        {
            player.transform.Translate(dist,Space.World);
        }
    }
    void Crack()
    {
        crack = !crack;
        if(crack)
            amplitude *= 3;
        else
            amplitude /= 3;
    }
    void AmpInvert()
    {
        amplitude *= -1;
    }

}
