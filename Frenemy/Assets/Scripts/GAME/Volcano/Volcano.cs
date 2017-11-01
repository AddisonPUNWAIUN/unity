using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : Terrains
{
    Transform ground;
    Transform obj;
    GameObject flameThrower;
    Player player;
    public int groundUnits = 5;
    int groundCols, groundRows;

    void Start ()
    {
        ground = transform.Find("ground");
        obj = transform.Find("Object");
        flameThrower = obj.Find("FlameThrower").gameObject;
        player = FindObjectOfType<Player>();
        groundCols = (int)ground.localScale.x * (10 / groundUnits);
        groundRows = (int)ground.localScale.z * (10 / groundUnits);
        InvokeRepeating("SpitFlame", 0.2f, 0.2f);
    }

    void SpitFlame()
    {
        float x = player.transform.position.x + Random.Range(-3f, 3f) * groundUnits;
        float z = player.transform.position.z + Random.Range(-3f, 6f) * groundUnits;
        Instantiate(flameThrower,
                    new Vector3(x, ground.position.y, z) ,
                    Quaternion.identity,
                    obj).AddComponent<FlameThrower>();
    }
}
